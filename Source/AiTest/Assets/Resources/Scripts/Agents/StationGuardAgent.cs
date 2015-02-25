using UnityEngine;
using System.Collections;

public class StationGuardAgent : Agent 
{
    protected override void OnStart() 
    {
        stateHandler = new NormalState(this);
	}
}
