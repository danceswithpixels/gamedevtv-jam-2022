using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Vector2 moveInput;
    // Rigidbody2D myRigidBody;
    // Animator myAnimator;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
        // myRigidBody = GetComponent<Rigidbody2D>();
        // myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Walk();
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
        Debug.Log(moveInput);
    }

    // void Walk()
    // {
    //     Vector2 playerVelocity= new Vector2(moveInput.x, myRigidBody.velocity.y);
    //     myRigidBody.velocity = playerVelocity;
    //     SetWalkingAnimation();
    // }

    // void SetWalkingAnimation()
    // {
    //     bool playerHasHorizontalSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;
    //     myAnimator.SetBool("isWalking", playerHasHorizontalSpeed);
    // }
}
