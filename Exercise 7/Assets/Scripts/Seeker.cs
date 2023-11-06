using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seeker : Agent
{
    [SerializeField]
    GameObject target;

    Vector3 seekForce;

    protected override void CalcSteeringForces()
    {
        seekForce = Seek(target);
        myPhysicsObject.ApplyForce(Seek(target));
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;

        Gizmos.DrawLine(transform.position, transform.position + myPhysicsObject.Velocity);
        
    }

    

}
