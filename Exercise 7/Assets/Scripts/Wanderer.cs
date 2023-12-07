using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Wanderer : Agent
{
    [SerializeField]
    float wanderTime = .1f;
    [SerializeField]
    float wanderRadius = 1f;
    [SerializeField]
    float boundingForce = 50f;

    public SceneManager manager;

    protected override void CalcSteeringForces()
    {
        totalForce += Wander(wanderTime, wanderRadius);
        totalForce += StayInBoundsForce() * boundingForce;
        //totalForce += Separate();

    }
    private void OnDrawGizmos()
    {
        // Vectors to help us calculate dot product and objects to avoid
        Vector3 rightVector;
        //  Red Gizmo visualizing direction
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(CalcFuturePosition(wanderTime), wanderRadius);
        Gizmos.DrawLine(transform.position, wanderTarget);

        // Green Box for the obstacle avoidance
        Vector3 directionVector = wanderTarget - transform.position;                     // Returns the direction of the agent in vector form
        float dist = directionVector.magnitude;
        Vector3 boxSize = new Vector3(myPhysicsObject.Radius*4, dist, myPhysicsObject.Radius/2);
        Vector3 boxCenter = Vector3.zero;
        boxCenter.y += dist / 2f;
        float angle = Mathf.Atan2(directionVector.y, directionVector.x) * Mathf.Rad2Deg;    // angle is the angle of the direction vector as it relates to the agent 0 degrees is on top
        

        Gizmos.color = Color.blue;
        //directionVector = directionVector.normalized;
        rightVector = DrawRotatedLine(transform.position, wanderTarget);


        Gizmos.color = Color.green;
        Quaternion rotation = Quaternion.Euler(0f, 0f, angle -90f); // Define the desired rotation
        Matrix4x4 rotationMatrix = Matrix4x4.Rotate(rotation); // Create a rotation matrix

        Gizmos.matrix = transform.localToWorldMatrix * rotationMatrix; // Apply the rotation
        Gizmos.DrawWireCube(boxCenter, boxSize);
        Gizmos.matrix = Matrix4x4.identity;

        
        // Lines to obstacles
        Gizmos.color = Color.yellow;
        foreach (Obstacle pos in manager.Obstacles)
        {
           Vector3 avoidDist = pos.Position - transform.position;
           
           if(
                InFront(directionVector, avoidDist) &&
                Close(avoidDist, dist) &&
                Vector3.AngleBetween(directionVector, avoidDist) < .3
           )
           {
                wanderTarget = wanderTarget - avoidDist*30;
                Gizmos.DrawLine(transform.position, pos.Position);
                Vector3 lineVector = pos.Position - transform.position;
            }
        }
    }


    Vector3 DrawRotatedLine(Vector3 startPoint, Vector3 endPoint)
    {
        Quaternion rotation = Quaternion.Euler(0f, 0f, 90f);
        Vector3 rotatedEndPoint = rotation * (endPoint - startPoint);
        rotatedEndPoint = rotatedEndPoint.normalized;
        Gizmos.DrawLine(startPoint, startPoint + rotatedEndPoint);
        return rotatedEndPoint;
    }

    bool Close(Vector3 obDist, float agntMag)
    {
        return obDist.magnitude < agntMag*2;
    }

    bool InFront(Vector3 headWay, Vector3 obst)
    {
        headWay= headWay.normalized;
        bool inFront = Vector3.Dot(headWay, obst) > 0;
        
        return inFront;
    }



    // to calculate if the boxes are obstacles are in the way we have to get their position and the position of the agent
    // we also need the direction vector of the agent because that is what we will be comparing the obstacle positions with
    // We can take the x and y coordinates that fall between the ranges of the green box

}
