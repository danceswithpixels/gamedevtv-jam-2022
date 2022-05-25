using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientNeeds : MonoBehaviour
{
    [SerializeField] GameObject patient;
    Patient patientScript;
    SpriteRenderer spriteRenderer;
    float originalY;
    public float floatStrength = 0.1f;
    public float floatSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        patientScript = patient.GetComponent<Patient>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        this.originalY = this.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        switch (patientScript.getNumNeeds()) {
            case 3: spriteRenderer.color = Color.red; break;
            case 2: spriteRenderer.color = Color.yellow; break;
            case 1: spriteRenderer.color = Color.green; break;
            default: spriteRenderer.enabled = false; break;
        }
        

        transform.position = new Vector3(
            transform.position.x,
            originalY + ((float) Mathf.Sin(Time.time * floatSpeed) * floatStrength),
            transform.position.z);
    }
}
