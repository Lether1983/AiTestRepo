using UnityEngine;
using System.Collections;

class State2 : StateHandler
{
    float speed = 2f;
    public override void Handler(AgentenControllscript agentControllScript)
    {
        AggressiveState(agentControllScript);
    }
    private void AggressiveState(AgentenControllscript agentControllScript)
    {
        if(agentControllScript.dist <= 2.5f && agentControllScript.dist > 1f)
        {
            agentControllScript.transform.LookAt(agentControllScript.other.position);
            agentControllScript.movedirection = agentControllScript.transform.forward * speed;
            agentControllScript.transform.gameObject.GetComponentInChildren<TextMesh>().text = "Fast Pursuit";
        }
        else if(agentControllScript.dist <= 1f)
        {
            agentControllScript.transform.gameObject.GetComponentInChildren<TextMesh>().text = "Light Melee Attack";
            agentControllScript.movedirection = Vector3.zero;
        }
        else
        {
            agentControllScript.transform.gameObject.GetComponentInChildren<TextMesh>().text = "Seek";
            agentControllScript.movedirection = Vector3.zero;
        }

        if(agentControllScript.Health > 50)
        {
            agentControllScript.stateHandler = new State1();
        }
    }
}
