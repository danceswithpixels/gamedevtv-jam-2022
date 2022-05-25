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
    PlayerItem playerItem;

    [SerializeField] GameObject item;
    [SerializeField] float walkSpeed = 5;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myBodyCollider = GetComponent<CapsuleCollider2D>();
        holdingItem = false;
        playerItem = item.GetComponent<PlayerItem>();
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
        Vector2 playerVelocity= new Vector2(moveInput.x * walkSpeed, myRigidBody.velocity.y);
        myRigidBody.velocity = playerVelocity;
        SetWalkingAnimation();
    }

    void SetWalkingAnimation()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;
        myAnimator.SetBool("isWalking", playerHasHorizontalSpeed);
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

    void OnPickUp()
    {
        if (myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Item")) && !holdingItem) 
        {
            Debug.Log("Can pick up");
            holdingItem = !holdingItem;
            playerItem.SetSprite(touchingItem.GetComponent<SpriteRenderer>());
            Destroy(touchingItem);
        } else if (!myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Item")) && holdingItem)
        {
            Debug.Log("Can drop up");
            holdingItem = !holdingItem;
            playerItem.RemoveSprite();
            // Instantiate the item on the ground in front of the player?
            Instantiate(touchingItem, myBodyCollider.transform.position, transform.rotation);
            touchingItem = null;
        }
    }
}
