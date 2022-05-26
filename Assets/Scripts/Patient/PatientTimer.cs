using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Pathfinding;


public class PatientTimer : MonoBehaviour
{
    [SerializeField] float expirationTime = 10f;
    [SerializeField] Image timerImage;
    [SerializeField] GameObject patient;
    [SerializeField] GameObject zombie;
    [SerializeField] GameObject patientSprite;
    [SerializeField] int getUpZombieSpeed = 10;
    [SerializeField] int getUpCuredSpeed = 30;

    float timerValue;
    public bool patientAlive;
    public float fillFraction;
    Patient patientScript;
    AIPath aiPath;

    // Start is called before the first frame update
    void Start()
    {
        patientAlive = true;
        patientScript = patient.GetComponent<Patient>();
        expirationTime *= patientScript.getNumNeeds();
        timerValue = expirationTime;
        aiPath = patient.GetComponent<AIPath>();
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
                while (patientScript.getNumNeeds() > 0) {
                    patientScript.resetNeed();
                }
            }

            timerImage.fillAmount = fillFraction;
        } else if (patientAlive) {
            if (standUp(patientSprite, getUpCuredSpeed)) {
                patient.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                aiPath.destination = GameObject.FindGameObjectWithTag("Ambulance").transform.position;
            }
        } else if (!patientAlive) {
            if (standUp(patientSprite, getUpZombieSpeed)) {
                Instantiate(zombie, patient.transform.position, transform.rotation);
                Destroy (patient.gameObject);
            }
        } 
    }

    bool standUp(GameObject sprite, int speed) {
        bool standingUp = true;
        if (sprite.transform.rotation.eulerAngles.z > 0 && !(sprite.transform.rotation.eulerAngles.z > 90))  {
                sprite.transform.Rotate(new Vector3(0,0,-speed * Time.deltaTime));
                standingUp = false;
        }
        return standingUp;
    }
}
