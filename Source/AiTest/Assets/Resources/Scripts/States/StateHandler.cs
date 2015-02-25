using UnityEngine;
using System.Collections;

public abstract class StateHandler
{
    protected Agent agent;
    public delegate void OnState();
    public event OnState OnEnter = delegate { };
    public event OnState OnUpdate = delegate { };
    public event OnState OnExit = delegate { };

    public virtual void Handler()
    {
        if(agent.dist <= 2.5f && agent.dist > 1f)
        {
            OnEnter();
        }
        else if (agent.dist <= 1f)
        {
            OnUpdate();
        }
        else
        {
            OnExit();
        }
    }
}
