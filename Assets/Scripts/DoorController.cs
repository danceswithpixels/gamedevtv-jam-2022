using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private AudioSource audioSource;

    [SerializeField] Sprite closedDoor;
    [SerializeField] Sprite openDoor;
    
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>(); 
    }

    private void OnTriggerEnter2D(Collider2D other) {
        audioSource.Play();
        spriteRenderer.sprite = openDoor;
    }


    private void OnTriggerExit2D(Collider2D other) {
        audioSource.Play();
        spriteRenderer.sprite = closedDoor;
    }
}
