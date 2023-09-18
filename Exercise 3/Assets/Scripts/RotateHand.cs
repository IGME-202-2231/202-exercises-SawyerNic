using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateHand : MonoBehaviour
{
    // Start is called before the first frame update
    float turnAmount = 0;
    [SerializeField]
    bool useDeltaTime;
    [SerializeField]
    GameObject arrow;
    void Start()
    {
        // For the numbers: 
        // 1.) instantiate each object
        //GameObject newNumber = Instantiate(/*prefab*/);
        
        // 2.) Trig to figure out x and y
        //newNumber.transform.position;
        //newNumber.GetComponent<TextMesh>().

    }

    // Update is called once per frame
    void Update()
    {
        float translation;

        if (useDeltaTime)
        {
            translation = Time.deltaTime * 6;
        }
        else
        {
            translation = (float).006;
        }
        turnAmount += translation;

        transform.rotation = Quaternion.Euler(0, 0, turnAmount);

    }
}
