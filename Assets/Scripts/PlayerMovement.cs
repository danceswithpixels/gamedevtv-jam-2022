using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Vector2 moveInput;
    Rigidbody2D myRigidBody;
    Animator myAnimator;
    public GameObject touchingItem;
    public bool holdingItem;
    Patient currentPatient;
    AudioSource audioSource;
    ItemSpawnController itemSpawnController;

    [SerializeField] Transform item;
    [SerializeField] float walkSpeed = 5;
    [SerializeField] AudioClip audioUseItem;
    [SerializeField] AudioClip audioPickUpItem;
    [SerializeField] AudioClip audioDropItem;

    static ArrayList itemTags = new ArrayList{"iBandage","iBone","iMedkit","iSaw","iSyringe"};
    bool isGamePaused = false;

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        holdingItem = false;
        audioSource = GetComponent<AudioSource>();
        itemSpawnController = FindObjectOfType<ItemSpawnController>();
    }

    void Update()
    {
        Walk();
        FlipSprite();
        if (holdingItem && touchingItem != null) 
        {
            touchingItem.transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
        }
    }

    void OnMove(InputValue value)
    {
        if(isGamePaused) { return; }
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

    void OnTriggerStay2D(Collider2D other) {
        if (other.tag == "Patient") 
        {
            currentPatient = other.gameObject.GetComponent<Patient>();
        } else if (itemTags.Contains(other.tag) && !holdingItem)
        {
            touchingItem = other.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Patient")
        {
            currentPatient = null;
        } else if (!holdingItem) 
        {
            touchingItem = null;
        }
        
    }

    void OnPickUp()
    {
        if (touchingItem != null) 
        {
            if (!holdingItem) 
            {
                    audioSource.PlayOneShot(audioPickUpItem);
                    holdingItem = !holdingItem;
                    touchingItem.transform.SetParent(gameObject.transform);
                    touchingItem.transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
                
        
            } else if (holdingItem)
            {
                if (currentPatient != null && (currentPatient.getNeed().tag.EndsWith(touchingItem.tag.Substring(1)))) 
                {
                    audioSource.PlayOneShot(audioUseItem);
                    currentPatient.resetNeed();
                    DestroyImmediate(touchingItem);
                    itemSpawnController.spawnItems();
                } else 
                {
                    audioSource.PlayOneShot(audioDropItem);
                    touchingItem.transform.SetParent(null);
                    touchingItem.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                    
                }
                holdingItem = !holdingItem;
                touchingItem = null;
            }
        }
        
    }

    public void PauseGame()
    {
        isGamePaused = true;
        Time.timeScale = 0;
        AudioListener.volume = 0f;
    }

    public void UnPauseGame() 
    {
        isGamePaused = false;
        Time.timeScale = 1;
        AudioListener.volume = 1f;
    }

    public bool IsGamePaused() 
    {
        return isGamePaused;
    }
}
