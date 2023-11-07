using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : Agent
{
    [SerializeField]
    float wanderTime = .1f;
    [SerializeField]
    float wanderRadius = 1f;

    protected override void CalcSteeringForces()
    {
        myPhysicsObject.ApplyForce(Wander(wanderTime, wanderRadius));
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(CalcFuturePosition(wanderTime), wanderRadius);

        Gizmos.DrawLine(transform.position, wanderTarget);
    }
}
