using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public Vector3 Position { get { return transform.position; } }
    public float size { get { return 1f; } }
    // Start is called before the first frame update
    [SerializeField]
    private Obstacle Obstacleobstacle;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, new Vector3(1f,1f,1f));
    }
}
