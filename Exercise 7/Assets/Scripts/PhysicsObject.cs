using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsObject : MonoBehaviour
{
    Vector3 position;
    Vector3 velocity;
    Vector3 direction;

    [SerializeField]
    Vector3 acceleration;

    [SerializeField]
    float maxSpeed = 1;
    public float MaxSpeed { get { return maxSpeed; } }
    public Vector3 Velocity { get { return velocity; } }

    [SerializeField]
    float Mass =1;

    private Vector2 ScreenMax
    {
        get { 
            return new Vector2(
                Camera.main.transform.position.x + Camera.main.orthographicSize*Camera.main.aspect,
                Camera.main.transform.position.y + Camera.main.orthographicSize
            );
        }
    }

    private Vector2 ScreenMin
    {
        get
        {
            return new Vector2(
                Camera.main.transform.position.x - Camera.main.orthographicSize*Camera.main.aspect,
                Camera.main.transform.position.y - Camera.main.orthographicSize
            );
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        ApplyGravity(Vector3.down * 9.81f);
        BounceOffEdges();
        velocity += acceleration * Time.deltaTime;
        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);

        position += velocity * Time.deltaTime;
        direction = velocity.normalized;

        transform.position = position;
        acceleration = Vector3.zero;
    }

    public void ApplyForce(Vector3 force)
    {
        acceleration += force / Mass;
    }

    private void ApplyGravity(Vector3 gravity)
    {
        acceleration += gravity;
    }

    private void BounceOffEdges()
    {
        if(position.x <= ScreenMin.x)
        {
            velocity.x *= -1;
            position.x = ScreenMin.x;
        }
        else if(position.x >= ScreenMax.x)
        {
            velocity.x *= -1;
            position.x = ScreenMax.x;
        }

        if(position.y <= ScreenMin.y)
        {
            velocity.y *= -1;
            position.y = ScreenMin.y;
        }
        else if(position.y >= ScreenMax.y)
        {
            velocity.y *= -1;
            position.y = ScreenMax.y;
        }
    }
}
