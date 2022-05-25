using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Pathfinding;

public class ZombieCollisionDetector : MonoBehaviour
{
    CapsuleCollider2D zombieCollider;

    void Start()
    {
        zombieCollider = GetComponent<CapsuleCollider2D>();
    }

    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("triggered entered");
        if(other.tag == "Player") {
                
                //Get player object
                //Get player health
                //Decrement health
                //Death screen
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
    }

    void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("collison entered");
    }

}
