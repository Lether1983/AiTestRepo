using UnityEngine;
using System.Collections;

public class AggressiveDogState : StateHandler
{
    StationDogAgent agent;
    float speed = 5f;

    public AggressiveDogState(StationDogAgent agent)
    {
        this.agent = agent;
    }
    public override void Handler()
    {
        AggressiveDogAgentState();  
    }
    public void AggressiveDogAgentState()
    {
        agent.transform.LookAt(agent.other.position);
        agent.movedirection = agent.transform.forward * speed;
        agent.transform.gameObject.GetComponentInChildren<TextMesh>().text = "Rush";

        if(agent.Health > 50)
        {
            agent.stateHandler = new NormalDogState(agent);
        }
    }
}
