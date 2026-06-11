using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class playermove : MonoBehaviour
{

    public float playerSpeed = 20f;
    private CharacterController myCC;
    public Animator camAnim;
    private bool isWalking;

    private Vector3 inputVector;
    private Vector3 movementVector;
    private float myGravity = -10f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myCC = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        MovePlayer();
        CheckForHeadBob();

        camAnim.SetBool("isWalking", isWalking);
    }

    void CheckForHeadBob()
    {
        if (myCC.velocity.magnitude > 0.1f)
        {
            isWalking = true;
        }
        else
        {
            isWalking = false;
        }
    }

    void GetInput()
    {
        inputVector = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        inputVector.Normalize();
        inputVector = transform.TransformDirection(inputVector);

        movementVector = (inputVector * playerSpeed) + (Vector3.up * myGravity);
    }
    
    void MovePlayer()
    {
        myCC.Move(movementVector *  Time.deltaTime);
    }
}
