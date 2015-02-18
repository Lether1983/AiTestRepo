using UnityEngine;
using System.Collections;

public class AgentenControllscript : MonoBehaviour 
{
    Vector3 movedirection = Vector3.zero;
	// Use this for initialization

	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        Transform other = GameObject.FindGameObjectWithTag("Player").transform;
        
        if(other)
        {
            CharacterController AgentenController = GetComponent<CharacterController>();

            float dist = Vector3.Distance(this.transform.position, other.transform.position);

            if(dist <= 2.5f && dist > 1f)
            {
                this.gameObject.GetComponentInChildren<TextMesh>().text = "Approach";
                this.gameObject.transform.LookAt(other);
                movedirection = this.transform.forward;
            }
            else if (dist <= 1f)
            {
                this.gameObject.GetComponentInChildren<TextMesh>().text = "Attack";
                movedirection = Vector3.zero;
            }
            else
            {
                this.gameObject.GetComponentInChildren<TextMesh>().text = "Idle";
                movedirection = Vector3.zero;
            }
            AgentenController.Move(movedirection * Time.deltaTime);
        }
	}
}
