using UnityEngine;
using System.Collections;

public class PatrolAgressiveState : StateHandler 
{
    Vector3 position;
    float speed = 4f;
    PatrolGuardAgent agent;

    public PatrolAgressiveState(PatrolGuardAgent agent)
    {
        this.agent = agent;
        position = agent.WaypointArray[Random.Range(0, agent.WaypointArray.Length)].transform.position;
    }
    public override void Handler()
    {
        AggressivePatrolAgentState();
    }

    public void AggressivePatrolAgentState()
    {
        if (agent.dist <= 2.5f && agent.dist > 1f)
        {
            agent.transform.LookAt(agent.other.position);
            agent.movedirection = agent.transform.forward * speed;
            agent.transform.gameObject.GetComponentInChildren<TextMesh>().text = "Fast Pursuit";
        }
        else if (agent.dist <= 1f)
        {
            agent.transform.gameObject.GetComponentInChildren<TextMesh>().text = "Try to Catch";
            agent.movedirection = Vector3.zero;
        }
        else
        {
            if (Vector3.Distance(agent.transform.position, position) <= 0.5f)
            {
                position = agent.WaypointArray[Random.Range(0, agent.WaypointArray.Length)].transform.position;
            }

            agent.transform.LookAt(position);
            agent.movedirection = agent.transform.forward * speed;
            agent.transform.gameObject.GetComponentInChildren<TextMesh>().text = "Patrol";
        }

        if (agent.Health > 50)
        {
            agent.stateHandler = new PatrolState(agent);
        }
    }
}
