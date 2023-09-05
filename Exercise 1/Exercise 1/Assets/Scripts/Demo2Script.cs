using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo2Script : MonoBehaviour
{
    [SerializeField]
    private string creatureName = "Frank";
    [SerializeField]
    private int health = 7;

    [SerializeField]
    private GameObject creaturePrefab;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Creature's name is " + creatureName);
        Debug.Log("Creature's health is " + health);
        Instantiate(creaturePrefab);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
