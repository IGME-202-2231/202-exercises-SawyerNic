using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Fleer : Agent
{
    [SerializeField]
    GameObject target;

    Vector3 seekForce;
    Vector3 vDistance;
    float distance;

    protected override void CalcSteeringForces()
    {
        DetectCollision();
        seekForce = Flee(target);
        myPhysicsObject.ApplyForce(Flee(target));
        totalForce += seekForce;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;

        Gizmos.DrawLine(transform.position, transform.position + myPhysicsObject.Velocity);

        Gizmos.DrawLine(transform.position, target.transform.position);


    }

    private void DetectCollision()
    {
        vDistance = transform.position - target.transform.position;
        distance = vDistance.magnitude;
        if (distance < radius)
        {
            myPhysicsObject.position = new Vector3(Random.Range(-10f,10f),Random.Range(-5f,5f));
            myPhysicsObject.Velocity = Vector3.zero;
        }
        
    }
}
