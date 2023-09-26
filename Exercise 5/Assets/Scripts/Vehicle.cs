using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Vehicle : MonoBehaviour
{
    Vector3 vehiclePosition = new Vector3(0, 0, 0);

    [SerializeField]
    float speed = 4f;

    Vector3 direction = Vector3.zero;

    Vector3 velocity = Vector3.zero;



    // Start is called before the first frame update
    void Start()
    {
        vehiclePosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        velocity = direction * speed * Time.deltaTime;

        vehiclePosition += velocity;

        //Leaving space for movement validation

        if (vehiclePosition.y > 5 || vehiclePosition.y < -5)
        {
            vehiclePosition.y = -vehiclePosition.y;

        }
        else if(vehiclePosition.x > 5 || vehiclePosition.x < -5)
        {
            vehiclePosition.x = -vehiclePosition.x;
        }
        transform.position = vehiclePosition;

    }

    public void SetDirection(Vector3 newDirection)
    {
        direction = newDirection.normalized;

        if(direction != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(Vector3.forward, direction);
        }
    }
}
