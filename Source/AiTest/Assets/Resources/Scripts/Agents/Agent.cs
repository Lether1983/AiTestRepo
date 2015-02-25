using UnityEngine;
using System.Collections;

public class Agent : MonoBehaviour 
{
    public Vector3 movedirection = Vector3.zero;
    public float dist;
    public Transform other;
    public int Health;
    public GameObject[] WaypointArray;
    public StateHandler stateHandler;
    CharacterController AgentenController;

    // Use this for initialization

    void Start()
    {
        AgentenController = GetComponent<CharacterController>();
        WaypointArray = GameObject.FindGameObjectsWithTag("Waypoint");
        OnStart();
        Health = 100;
    }

    protected virtual void OnStart()
    {

    }

    // Update is called once per frame
    void Update()
    {
        other = GameObject.FindGameObjectWithTag("Player").transform;

        if (Input.GetKeyDown(KeyCode.L))
        {
            Health = Health - 50;
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            Health = Health + 50;
        }

        if (other)
        {
            dist = Vector3.Distance(this.transform.position, other.transform.position);
            stateHandler.Handler();
        }
        AgentenController.Move(movedirection * Time.deltaTime);
    }
}
