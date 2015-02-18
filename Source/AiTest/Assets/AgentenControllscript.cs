using UnityEngine;
using System.Collections;

public class AgentenControllscript : MonoBehaviour 
{
    public Vector3 movedirection = Vector3.zero;
    public float dist;
    public Transform other;
    public int Health;
    public StateHandler stateHandler;
    
	// Use this for initialization

	void Start () 
    {
        stateHandler = new State1();
        Health = 100;
	}
	
	// Update is called once per frame
	void Update () 
    {
        other = GameObject.FindGameObjectWithTag("Player").transform;

        if(Input.GetKeyDown(KeyCode.L))
        {
            Health = Health - 50;
        }
        if(Input.GetKeyDown(KeyCode.K))
        {
            Health = Health + 50;
        }

        if(other)
        {
            CharacterController AgentenController = GetComponent<CharacterController>();
            dist = Vector3.Distance(this.transform.position, other.transform.position);
            stateHandler.Handler(this);
            AgentenController.Move(movedirection * Time.deltaTime);
        }
	}
}
