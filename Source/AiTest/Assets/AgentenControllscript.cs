using UnityEngine;
using System.Collections;

public class AgentenControllscript : MonoBehaviour 
{
    public Vector3 movedirection = Vector3.zero;
    private StateHandler stateHandler;
    public float dist;
    public Transform other;
	// Use this for initialization

	void Start () 
    {
        stateHandler = new State1();
	}
	
	// Update is called once per frame
	void Update () 
    {
        other = GameObject.FindGameObjectWithTag("Player").transform;

        if(other)
        {
            CharacterController AgentenController = GetComponent<CharacterController>();
            dist = Vector3.Distance(this.transform.position, other.transform.position);
            stateHandler.Handler(this);
            AgentenController.Move(movedirection * Time.deltaTime);
        }
	}
}
