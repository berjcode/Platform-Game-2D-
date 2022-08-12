using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    PlayerController playerController;

    void Start()
    {
        playerController= GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump")&& playerController.isGrounded)
        {

            playerController.jumpPlayer();
            playerController.canDoubleJump = true;

        }
        else if(Input.GetButtonDown("Jump") && !playerController.isGrounded && playerController.canDoubleJump)
        {
            playerController.DoubleJump();
           playerController.canDoubleJump= false; 
        }
        
    }
}
