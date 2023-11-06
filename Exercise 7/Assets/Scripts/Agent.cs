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

    // Start is called before the first frame update
    void Start()
    {
        
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
        Vector3 desiredVelocity = transform.position - targetPos ;
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
}
