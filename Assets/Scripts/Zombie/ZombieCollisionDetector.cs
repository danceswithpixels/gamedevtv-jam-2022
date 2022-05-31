using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Pathfinding;

public class ZombieCollisionDetector : MonoBehaviour
{
    CapsuleCollider2D zombieCollider;
    PlayerMovement playerMovement;

    void Start()
    {
        zombieCollider = GetComponent<CapsuleCollider2D>();
        playerMovement = FindObjectOfType<PlayerMovement>();
    }

    void Update()
    {
    }

    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Player") {
            playerMovement.PauseGame();
        } else if (other.gameObject.tag == "Patient") {
            other.gameObject.GetComponentInChildren<PatientTimer>().patientAlive = false;
        }
    }

}
