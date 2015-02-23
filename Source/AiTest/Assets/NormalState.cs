using UnityEngine;
using System;
using System.Collections;

class NormalState : StateHandler 
{
    AgentenControllscript agentControllScript;

    public NormalState(AgentenControllscript agentControllScript)
    {
        this.agentControllScript = agentControllScript;
    }
    public override void Handler(AgentenControllscript agentControllScript)
    {
        NormalAgentState(agentControllScript);
    }
    private void NormalAgentState(AgentenControllscript agentControllScript)
    {
        if(agentControllScript.dist <= 2.5f && agentControllScript.dist > 1f)
        {
            agentControllScript.transform.LookAt(agentControllScript.other.position);
            agentControllScript.movedirection = agentControllScript.transform.forward;
            agentControllScript.transform.gameObject.GetComponentInChildren<TextMesh>().text = "Pursuit";
        }
        else if(agentControllScript.dist <= 1f)
        {
            agentControllScript.transform.gameObject.GetComponentInChildren<TextMesh>().text = "Heavy Melee Attack";
            agentControllScript.movedirection = Vector3.zero;
        }
        else
        {
            agentControllScript.transform.gameObject.GetComponentInChildren<TextMesh>().text = "Idle";
            agentControllScript.movedirection = Vector3.zero;
        }

        if(agentControllScript.Health <= 50)
        {
            agentControllScript.stateHandler = new State2(agentControllScript);
            
        }
    }
}
