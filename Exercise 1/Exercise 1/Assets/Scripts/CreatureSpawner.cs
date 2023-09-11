using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject Prefab;

    float xPosition = 0f;
    float zPosition = 0f;
    // s
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 3; i++)
        { 
            GameObject instance = Instantiate(Prefab, new Vector3(xPosition + i*3, 0f, zPosition),Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
