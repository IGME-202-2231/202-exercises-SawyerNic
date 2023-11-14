using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentManager : MonoBehaviour
{
    [SerializeField]
    private Wanderer wanderPrefab;

    private List<Agent> agents;

    public List<Agent> Agents { get { return agents; } }

    [SerializeField]
    uint wandererCount;
    // Start is called before the first frame update
    void Start()
    {
        agents = new List<Agent>();
        for(uint i = 0; i < wandererCount; i++)
        {
            SpawnWanderer();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnWanderer()
    {
        Wanderer newAgent = Instantiate(wanderPrefab, transform);
        newAgent.AgentManager = this;
        agents.Add(newAgent);
    }
}
