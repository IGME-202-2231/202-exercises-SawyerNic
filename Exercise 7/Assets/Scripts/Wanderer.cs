using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wanderer : Agent
{
    [SerializeField]
    float wanderTime = .1f;
    [SerializeField]
    float wanderRadius = 1f;
    [SerializeField]
    float boundingForce = 50f;

    
    

    protected override void CalcSteeringForces()
    {
        totalForce += Wander(wanderTime, wanderRadius);
        totalForce += StayInBoundsForce() * boundingForce;
        totalForce += Separate();

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(CalcFuturePosition(wanderTime), wanderRadius);

        Gizmos.DrawLine(transform.position, wanderTarget);
    }


}
