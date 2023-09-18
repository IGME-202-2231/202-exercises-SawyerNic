using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    float radius = 2.2f;
    [SerializeField]
    TextMesh clockText;
    public List<TextMesh> objectList = new List<TextMesh>();
    // Start is called before the first frame update
    void Start()
    {
        //Instantiate(TextMesh, Transform(0,0,0), Quaternion.Euler(0, 0, 100));

        float angleStep = 360f / 12;

        for (int i = 0; i < 12; i++)
        {
            float angle = (1+i) * angleStep;
            float x = Mathf.Sin(Mathf.Deg2Rad * angle) * radius;
            float y = Mathf.Cos(Mathf.Deg2Rad * angle) * radius;

            Vector3 objectPosition = new Vector3(x, y, 0f);
            TextMesh newObject = Instantiate(clockText, objectPosition, Quaternion.identity);
            newObject.text = (i+1).ToString();
            objectList.Add(newObject);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
