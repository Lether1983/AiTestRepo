using UnityEngine;
using System.Collections;

public class NormalDogState : StateHandler
{
    StationDogAgent agent;

    public NormalDogState(StationDogAgent agent)
    {
        this.agent = agent;
    }
    public override void Handler()
    {
        NormalDogAgentState();
    }
    private void NormalDogAgentState()
    {
        if(agent.dist <= 2.5f && agent.dist > 1f)
        {
            agent.transform.LookAt(agent.other.position);
            agent.movedirection = agent.transform.forward;
            agent.transform.gameObject.GetComponentInChildren<TextMesh>().text = "Pursuit";
        }
        else if(agent.dist <= 1f)
        {
            agent.transform.gameObject.GetComponentInChildren<TextMesh>().text = "Bite";
            agent.movedirection = Vector3.zero;
        }
        else
        {
            agent.transform.gameObject.GetComponentInChildren<TextMesh>().text = "Sleep";
            agent.movedirection = Vector3.zero;
        }

        if(agent.Health <= 50)
        {
            agent.stateHandler = new AggressiveDogState(agent);
        }
    }
}
