using UnityEngine;
using System;
using System.Collections;

class NormalState : StateHandler 
{
    StationGuardAgent agent;

    public NormalState(StationGuardAgent agent)
    {
        this.agent = agent;
    }
    public override void Handler()
    {
        NormalAgentState();
    }
    private void NormalAgentState()
    {
        if(agent.dist <= 2.5f && agent.dist > 1f)
        {
            agent.transform.LookAt(agent.other.position);
            agent.movedirection = agent.transform.forward;
            agent.transform.gameObject.GetComponentInChildren<TextMesh>().text = "Pursuit";
        }
        else if(agent.dist <= 1f)
        {
            agent.transform.gameObject.GetComponentInChildren<TextMesh>().text = "Heavy Melee Attack";
            agent.movedirection = Vector3.zero;
        }
        else
        {
            agent.transform.gameObject.GetComponentInChildren<TextMesh>().text = "Idle";
            agent.movedirection = Vector3.zero;
        }

        if(agent.Health <= 50)
        {
            agent.stateHandler = new AggressiveState(agent);
            
        }
    }
}
