using UnityEngine;
using System.Collections;

class State2 : StateHandler
{
    Vector3 position;
    float speed = 2f;
    AgentenControllscript agentControllScript;

    public State2(AgentenControllscript agentControllScript)
    {
        this.agentControllScript = agentControllScript;
        position = agentControllScript.WaypointArray[Random.Range(0, agentControllScript.WaypointArray.Length)].transform.position;
    }

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
             
            if(Vector3.Distance(agentControllScript.transform.position, position) <= 0.5f)
            {
                position = agentControllScript.WaypointArray[Random.Range(0, agentControllScript.WaypointArray.Length)].transform.position;
            }

            agentControllScript.transform.LookAt(position);
            agentControllScript.movedirection = agentControllScript.transform.forward;
            agentControllScript.transform.gameObject.GetComponentInChildren<TextMesh>().text = "Seek";
        }

        if(agentControllScript.Health > 50)
        {
            agentControllScript.stateHandler = new State1(agentControllScript);
        }
    }
}
