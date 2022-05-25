using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PatientTimer : MonoBehaviour
{
    [SerializeField] float expirationTime = 10f;
    [SerializeField] Image timerImage;
    [SerializeField] GameObject patient;
    [SerializeField] GameObject zombie;

    float timerValue;
    public bool patientAlive;
    public float fillFraction;
    Patient patientScript;

    // Start is called before the first frame update
    void Start()
    {
        patientAlive = true;
        patientScript = patient.GetComponent<Patient>();
        expirationTime *= patientScript.getNumNeeds();
        timerValue = expirationTime;
    }

    // Update is called once per frame
    void Update()
    {
        timerValue -= Time.deltaTime;
        if (patientAlive && patientScript.getNumNeeds() > 0) {
            if (timerValue > 0) {
                fillFraction = timerValue / expirationTime;
            } else {
                patientAlive = false;
            }

            timerImage.fillAmount = fillFraction;
        } else if (!patientAlive) {
            Instantiate(zombie, patient.transform.position, transform.rotation);
            Destroy (patient.gameObject);
        }
    }
}
