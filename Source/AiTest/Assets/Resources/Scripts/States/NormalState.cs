using UnityEngine;
using System;
using System.Collections;

class NormalState : StateHandler 
{
    public NormalState(Agent agent)
    {
        this.agent = agent;
        OnEnter += PursuitMode;
        OnUpdate += HeavyMeleeAttackMode;
        OnExit += IdleMode;
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
            agent.stateHandler = new AggressiveState(agent);
        }
    }

    private void IdleMode()
    {
        agent.transform.gameObject.GetComponentInChildren<TextMesh>().text = "Idle";
        agent.movedirection = Vector3.zero;
    }

    private void HeavyMeleeAttackMode()
    {
        agent.transform.gameObject.GetComponentInChildren<TextMesh>().text = "Heavy Melee Attack";
        agent.movedirection = Vector3.zero;
    }

    private void PursuitMode()
    {
        agent.transform.LookAt(agent.other.position);
        agent.movedirection = agent.transform.forward;
        agent.transform.gameObject.GetComponentInChildren<TextMesh>().text = "Pursuit";
    }
}
