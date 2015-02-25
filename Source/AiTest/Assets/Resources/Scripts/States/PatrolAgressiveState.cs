using UnityEngine;
using System.Collections;

public class PatrolAgressiveState : StateHandler 
{
    Vector3 position;
    float speed = 4f;

    public PatrolAgressiveState(Agent agent)
    {
        this.agent = agent;
        OnEnter += FastPursuitMode;
        OnUpdate += TryCatchMode;
        OnExit += PatrolMode;
        position = agent.WaypointArray[Random.Range(0, agent.WaypointArray.Length)].transform.position;
    }
    public override void Handler()
    {
        ChangeAgentState();
        base.Handler();
    }

    public void ChangeAgentState()
    {
        if (agent.Health > 50)
        {
            agent.stateHandler = new PatrolState(agent);
        }
    }

    private void PatrolMode()
    {
        if (Vector3.Distance(agent.transform.position, position) <= 0.5f)
        {
            position = agent.WaypointArray[Random.Range(0, agent.WaypointArray.Length)].transform.position;
        }

        agent.transform.LookAt(position);
        agent.movedirection = agent.transform.forward * speed;
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
