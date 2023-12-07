using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SceneManager : MonoBehaviour
{
    [SerializeField]
    List<PhysicsObject> physicsObjects;

    [SerializeField]
    private List<Obstacle> obstacles;
    [SerializeField]
    float squareCount;
    public Obstacle square;

    public List<Obstacle> Obstacles { get { return obstacles; } }

    private Vector2 mousePos;

    private float xRange;
    private float yRange;
    // Start is called before the first frame update
    void Start()
    {
        for (uint i = 0; i < squareCount; i++) {
            xRange = Random.Range(-9f, 9f);
            yRange = Random.Range(-4f, 4f);
            Vector3 position = new Vector3(xRange,yRange,0f);
            obstacles.Add(Instantiate(square, position, Quaternion.identity));
        }
    }

    // Update is called once per frame
    void Update()
    {
        /*mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        physicsObjects[0].ApplyForce(((mousePos - (Vector2)physicsObjects[0].transform.position)*3));*/
    }

    private void OnDrawGizmos()
    {
        /*Gizmos.color = Color.magenta;
        Gizmos.DrawLine(Vector2.zero,mousePos);*/
    }
}
