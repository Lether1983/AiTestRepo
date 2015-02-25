using UnityEngine;
using System.Collections;

public class NormalDogState : StateHandler
{

    public NormalDogState(Agent agent)
    {
        this.agent = agent;
        OnEnter += PursuitDogMode;
        OnUpdate += BiteDogMode;
        OnExit += SleepDogMode;
    }
    public override void Handler()
    {
        ChangeAgentState();
        base.Handler();
    }
    private void ChangeAgentState()
    {
        if(agent.Health <= 50)
        {
            agent.stateHandler = new AggressiveDogState(agent);
        }
    }

    private void SleepDogMode()
    {
        agent.transform.gameObject.GetComponentInChildren<TextMesh>().text = "Sleep";
        agent.movedirection = Vector3.zero;
    }

    private void BiteDogMode()
    {
        agent.transform.gameObject.GetComponentInChildren<TextMesh>().text = "Bite";
        agent.movedirection = Vector3.zero;
    }

    private void PursuitDogMode()
    {
        agent.transform.LookAt(agent.other.position);
        agent.movedirection = agent.transform.forward;
        agent.transform.gameObject.GetComponentInChildren<TextMesh>().text = "Pursuit";
    }
}
