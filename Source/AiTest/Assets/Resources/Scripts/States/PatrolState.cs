using UnityEngine;
using System.Collections;

public class PatrolState : StateHandler 
{
    Vector3 position;
    float speed = 2f;

    public PatrolState(Agent agent)
    {
        this.agent = agent;
        OnEnter += FastPursuitMode;
        OnUpdate += TryCatchMode;
        OnExit += PatrolMode;
        position = agent.WaypointArray[Random.Range(0, agent.WaypointArray.Length)].transform.position;
    }

    public override void Handler()
    {
        PatrolAgentState();
        base.Handler();
    }

    private void PatrolAgentState()
    {
        if (agent.Health <= 50)
        {
            agent.stateHandler = new PatrolAgressiveState(agent);
        }
    }

    private void PatrolMode()
    {
        if (Vector3.Distance(agent.transform.position, position) <= 0.5f)
        {
            position = agent.WaypointArray[Random.Range(0, agent.WaypointArray.Length)].transform.position;
        }

        agent.transform.LookAt(position);
        agent.movedirection = agent.transform.forward;
        agent.transform.gameObject.GetComponentInChildren<TextMesh>().text = "Patrol";
    }

    private void TryCatchMode()
    {
        agent.transform.gameObject.GetComponentInChildren<TextMesh>().text = "Try to Catch";
        agent.movedirection = Vector3.zero;
    }

    private void FastPursuitMode()
    {
        agent.transform.LookAt(agent.other.position);
        agent.movedirection = agent.transform.forward * speed;
        agent.transform.gameObject.GetComponentInChildren<TextMesh>().text = "Fast Pursuit";
    }
}
