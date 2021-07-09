using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 20.0f;
    //private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;
    public bool active = false;

    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        controller.detectCollisions = true; 
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }
   
        Vector3 move = new Vector3(Input.GetAxis("Horizontal") * 1, 0, Input.GetAxis("Vertical") * 1);
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.name == "Ball" && !active)
        {
            active = true;
            hit.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            hit.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            hit.gameObject.transform.parent = gameObject.transform;
            hit.gameObject.transform.localPosition = new Vector3(2.5f, 2.57f,1.49f);
            
            
        }
    }
}


