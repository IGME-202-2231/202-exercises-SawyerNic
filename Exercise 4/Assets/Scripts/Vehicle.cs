using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    Vector3 vehiclePosition = new Vector3(0,0,0);

    float speed = 4f;

    Vector3 direction = new Vector3(1,0,0);

    Vector3 velocity = new Vector3(0,0,0);
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

        transform.position = vehiclePosition;
    }
}
