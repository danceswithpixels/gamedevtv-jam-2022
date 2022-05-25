using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Vector2 moveInput;
    Rigidbody2D myRigidBody;
    Animator myAnimator;
    CapsuleCollider2D myBodyCollider;
    GameObject touchingItem;
    bool holdingItem;

    [SerializeField] Transform item;
    [SerializeField] float walkSpeed = 5;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myBodyCollider = GetComponent<CapsuleCollider2D>();
        holdingItem = false;

    }

    // Update is called once per frame
    void Update()
    {
        Walk();
        FlipSprite();
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void Walk()
    {
        Vector2 playerVelocity= new Vector2(moveInput.x * walkSpeed, moveInput.y*walkSpeed);
        myRigidBody.velocity = playerVelocity;
        SetWalkingAnimation();
    }

    void SetWalkingAnimation()
    {
        bool playerHasSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon || Mathf.Abs(myRigidBody.velocity.y) > Mathf.Epsilon;
        myAnimator.SetBool("isWalking", playerHasSpeed);
    }

    void FlipSprite() 
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;
        if (playerHasHorizontalSpeed) 
        {
            transform.localScale = new Vector2(Mathf.Sign(myRigidBody.velocity.x), 1f);
        }
        
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Item")) && !holdingItem) 
        {
            touchingItem = other.gameObject;
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "nSaw" && !holdingItem)
        {
            touchingItem = other.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D other) {

        if (!holdingItem) 
        {
            touchingItem = null;
        }
        
    }

    void OnPickUp()
    {
        if (myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Item")) && !holdingItem) 
        {
            Debug.Log("Can pick up");
            holdingItem = !holdingItem;
            touchingItem.transform.SetParent(gameObject.transform);
            touchingItem.transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
        } else if (!myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Item")) && holdingItem)
        {
            Debug.Log("Can drop up");
            holdingItem = !holdingItem;
            touchingItem.transform.SetParent(null);
            touchingItem.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            touchingItem = null;
        }
    }
}
