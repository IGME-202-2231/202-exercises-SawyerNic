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
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float sec = 100 * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0, 0, 45+sec);
    }
}
