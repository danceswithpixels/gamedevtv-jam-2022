using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientSpawnController : MonoBehaviour
{
    [SerializeField] int maxPatients = 1;
    [SerializeField] GameObject patientPrefab;
    public int safeZone = 20;
    GameObject[] patientSpawns;
    // Start is called before the first frame update
    void Start()
    {
        patientSpawns = GameObject.FindGameObjectsWithTag("pSpawn");
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Patient").Length < maxPatients) {
            List<GameObject> spawns = new List<GameObject>(patientSpawns);
            List<GameObject> availableSpawns = new List<GameObject>();

            foreach (GameObject spawn in spawns) {
                if (spawn.GetComponent<PatientSpawn>().spawnAvailable) {
                    availableSpawns.Add(spawn);
                }
            }

            if (availableSpawns.Count > 0) {
                GameObject spawn = availableSpawns[Random.Range(0, availableSpawns.Count)];
                Instantiate(patientPrefab, spawn.transform.position, transform.rotation);
                spawn.GetComponent<PatientSpawn>().spawnAvailable = false;
                availableSpawns.Remove(spawn);
            }

        }
    }
}
