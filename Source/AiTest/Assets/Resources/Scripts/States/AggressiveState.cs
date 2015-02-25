using UnityEngine;
using System.Collections;

class AggressiveState : StateHandler
{
    Vector3 position;
    float speed = 2f;

    public AggressiveState(Agent agent)
    {
        this.agent = agent;
        OnEnter += FastPursuitMode;
        OnUpdate += LightMeleeAttackMode;
        OnExit += SeekMode;
        position = agent.WaypointArray[Random.Range(0, agent.WaypointArray.Length)].transform.position;
    }

    public override void Handler()
    {
        ChangeAgentState();
        base.Handler();
    }

    private void ChangeAgentState()
    {
        if(agent.Health > 50)
        {
            agent.stateHandler = new NormalState(agent);
        }
    }

    private void SeekMode()
    {
        if(Vector3.Distance(agent.transform.position,position) <= 0.5f)
        {
            position = agent.WaypointArray[Random.Range(0, agent.WaypointArray.Length)].transform.position;
        }

        agent.transform.LookAt(position);
        agent.movedirection = agent.transform.forward;
        agent.transform.gameObject.GetComponentInChildren<TextMesh>().text = "Seek";
    }

    private void LightMeleeAttackMode()
    {
        agent.transform.gameObject.GetComponentInChildren<TextMesh>().text = "Light Melee Attack";
        agent.movedirection = Vector3.zero;
    }

    private void FastPursuitMode()
    {
        agent.transform.LookAt(agent.other.position);
        agent.movedirection = agent.transform.forward * speed;
        agent.transform.gameObject.GetComponentInChildren<TextMesh>().text = "Fast Pursuit";
    }
}
