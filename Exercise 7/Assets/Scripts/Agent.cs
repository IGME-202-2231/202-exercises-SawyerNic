using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Agent : MonoBehaviour
{
    [SerializeField]
    public PhysicsObject myPhysicsObject;

    [SerializeField]
    float maxForce = 10;

    [SerializeField]
    protected float radius;

    protected Vector3 wanderTarget;

    float wanderAngle;
    float perlinOffset;

    // Start is called before the first frame update
    void Start()
    {
        wanderAngle = Random.Range(0.0f, Mathf.PI * 2);
        perlinOffset = Random.Range(0, 10000);
    }

    // Update is called once per frame
    void Update()
    {
        CalcSteeringForces();

    }

    protected abstract void CalcSteeringForces();


    protected Vector3 Seek(Vector3 targetPos)
    {
        Vector3 desiredVelocity = targetPos - transform.position;
        desiredVelocity = desiredVelocity.normalized * myPhysicsObject.MaxSpeed;

        Vector3 steeringForce = desiredVelocity - myPhysicsObject.Velocity;
        steeringForce = Vector3.ClampMagnitude(steeringForce, maxForce);

        return steeringForce;
    }

    protected Vector3 Seek(GameObject target)
    {
        return Seek(target.transform.position);
    }

    protected Vector3 Flee(Vector3 targetPos)
    {
        Vector3 desiredVelocity = transform.position - targetPos;
        desiredVelocity = desiredVelocity.normalized * myPhysicsObject.MaxSpeed;

        Vector3 steeringForce = desiredVelocity - myPhysicsObject.Velocity;
        steeringForce = Vector3.ClampMagnitude(steeringForce, maxForce);

        return steeringForce;
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
}
