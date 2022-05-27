using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientSpawn : MonoBehaviour
{
    public bool spawnAvailable = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("PatientSpawn.OnTriggerEnter2D");
        if (other.gameObject.layer == LayerMask.NameToLayer("Patient") || other.gameObject.layer == LayerMask.NameToLayer("Zombie")) {
            spawnAvailable = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        Debug.Log("PatientSpawn.OnTriggerExit2D");
        if (other.gameObject.layer == LayerMask.NameToLayer("Patient") || other.gameObject.layer == LayerMask.NameToLayer("Zombie")) {
            spawnAvailable = true;
        }
    }
}
