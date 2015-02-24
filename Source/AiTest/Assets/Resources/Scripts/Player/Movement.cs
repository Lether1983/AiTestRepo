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
        movedirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        movedirection = transform.TransformDirection(movedirection* speed);
        
        charController.Move(movedirection * Time.deltaTime);
    }
}
