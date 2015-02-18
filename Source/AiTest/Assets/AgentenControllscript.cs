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
            float dist = Vector3.Distance(this.transform.position, other.transform.position);

            if(dist <= 2.5f && dist > 1f)
            {
                this.gameObject.GetComponentInChildren<TextMesh>().text = "Approach";
            }
            else if (dist <= 1f)
            {
                this.gameObject.GetComponentInChildren<TextMesh>().text = "Attack";
            }
            else
            {
                this.gameObject.GetComponentInChildren<TextMesh>().text = "Idle";
            }
        }
	}
}
