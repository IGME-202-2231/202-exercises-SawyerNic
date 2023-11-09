using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Agent : MonoBehaviour
{
    [SerializeField]
    public PhysicsObject myPhysicsObject;

    [SerializeField]
    float maxForce;

    [SerializeField]
    protected float radius;

    protected Vector3 wanderTarget;

    float wanderAngle;
    float perlinOffset;

    protected Vector3 totalForce;

    // Start is called before the first frame update
    void Start()
    {
        maxForce = 10;
        wanderAngle = Random.Range(0.0f, Mathf.PI * 2);
        perlinOffset = Random.Range(0, 10000);
    }

    // Update is called once per frame
    void Update()
    {
        totalForce = Vector3.zero;

        CalcSteeringForces();

        totalForce = Vector3.ClampMagnitude(totalForce, maxForce);
        myPhysicsObject.ApplyForce(totalForce);
    }

    protected abstract void CalcSteeringForces();


    protected Vector3 Seek(Vector3 targetPos)
    {
        Vector3 desiredVelocity = targetPos - transform.position;
        desiredVelocity = desiredVelocity.normalized * myPhysicsObject.MaxSpeed;

        return desiredVelocity - myPhysicsObject.Velocity;
    }

    protected Vector3 Seek(GameObject target)
    {
        return Seek(target.transform.position);
    }

    protected Vector3 Flee(Vector3 targetPos)
    {
        Vector3 desiredVelocity = transform.position - targetPos;
        desiredVelocity = desiredVelocity.normalized * myPhysicsObject.MaxSpeed;


        return desiredVelocity - myPhysicsObject.Velocity;
    }

    protected Vector3 Flee(GameObject target)
    {
        return Flee(target.transform.position);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);

    }

    protected Vector3 CalcFuturePosition(float time)
    {
        return transform.position + (myPhysicsObject.Velocity * time);
    }

    protected Vector3 Wander(float time, float radius)
    {
        Vector3 futurePos = CalcFuturePosition(time);

        wanderAngle += (0.5f - Mathf.PerlinNoise(
            transform.position.x * .1f + perlinOffset,
            transform.position.y * .1f + perlinOffset
        )) * Mathf.PI*Time.deltaTime;


        Vector3 pointOnCircle = new Vector3(
            Mathf.Cos(wanderAngle) * radius,
            Mathf.Sin(wanderAngle) * radius
        );

        wanderTarget = futurePos + pointOnCircle;

        return Seek(futurePos + pointOnCircle);
    }

    protected Vector3 StayInBoundsForce()
    {
        if(
            transform.position.x < myPhysicsObject.ScreenMin.x ||
            transform.position.x > myPhysicsObject.ScreenMax.x ||
            transform.position.y < myPhysicsObject.ScreenMin.y ||
            transform.position.y > myPhysicsObject.ScreenMax.y)
        {
            Vector3 camPosition = Camera.main.transform.position;
            camPosition.z = transform.position.z;
            return Seek(camPosition);
        }

        return Vector3.zero;
        
    }
}
