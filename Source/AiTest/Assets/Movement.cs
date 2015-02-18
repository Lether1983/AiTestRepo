using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    Vector3 movedirection = Vector3.zero;
    float speed = 2f;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update() 
    {
        CharacterController charController = GetComponent<CharacterController>();
        Transform other = GameObject.FindGameObjectWithTag("Exit").transform;
        movedirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        movedirection = transform.TransformDirection(movedirection* speed);

        float dist = Vector3.Distance(other.position, this.transform.position);

        if(dist <= 1)
        {
            Application.LoadLevel(1);
        }
        charController.Move(movedirection * Time.deltaTime);
    }
}
