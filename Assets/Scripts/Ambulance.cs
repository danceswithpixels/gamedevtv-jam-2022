using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ambulance : MonoBehaviour
{
    public int patientsSaved = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Patient") {
            patientsSaved++;
            // FindObjectOfType<PlayerMovement>().patientsSaved++;
            Destroy (other.gameObject);
        }
    }
}
