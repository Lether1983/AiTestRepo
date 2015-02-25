using UnityEngine;
using System.Collections;

public class AggressiveDogState : StateHandler
{
    float speed = 5f;

    public AggressiveDogState(Agent agent)
    {
        this.agent = agent;
        OnEnter += RushDogMode;
    }
    public override void Handler()
    {
        AggressiveDogAgentState();
        base.Handler();
    }
    public void AggressiveDogAgentState()
    {
        if(agent.Health > 50)
        {
            agent.stateHandler = new NormalDogState(agent);
        }
    }

    private void RushDogMode()
    {
        agent.transform.LookAt(agent.other.position);
        agent.movedirection = agent.transform.forward * speed;
        agent.transform.gameObject.GetComponentInChildren<TextMesh>().text = "Rush";
    }
}
