using UnityEngine;
using System.Collections;

public class StationDogAgent : Agent
{
    protected override void OnStart()
    {
        stateHandler = new NormalDogState(this);
    }
}
