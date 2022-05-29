using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    [SerializeField] Sprite closedDoor;
    [SerializeField] Sprite openDoor;
    
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();    
    }

    private void OnTriggerEnter2D(Collider2D other) {
        spriteRenderer.sprite = openDoor;
    }


    private void OnTriggerExit2D(Collider2D other) {
        spriteRenderer.sprite = closedDoor;
    }
}
