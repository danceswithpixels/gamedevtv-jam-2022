using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    [SerializeField] Sprite closedDoor;
    [SerializeField] Sprite openDoor;
    
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();    
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("entered trigger");
        if(other.gameObject.tag == "Player" 
        || other.gameObject.tag == "Patient") {
            spriteRenderer.sprite = openDoor;
        }
    }


    private void OnTriggerExit2D(Collider2D other) {
        Debug.Log("exited trigger");
        if(other.gameObject.tag == "Player" 
        || other.gameObject.tag == "Patient") {
            spriteRenderer.sprite = closedDoor;
        }
    }
}
