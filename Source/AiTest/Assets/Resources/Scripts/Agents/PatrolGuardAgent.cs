using UnityEngine;
using System.Collections;

public class PatrolGuardAgent : Agent
{
    protected override void OnStart ()
    {
        stateHandler = new PatrolState(this);
    }
}
