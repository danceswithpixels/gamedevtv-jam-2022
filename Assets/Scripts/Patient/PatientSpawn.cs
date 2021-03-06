using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientSpawn : MonoBehaviour
{
    public bool spawnAvailable = true;
    private int safeZone;

    void Start()
    {
        safeZone = FindObjectOfType<PatientSpawnController>().safeZone;
    }

    void Update()
    {
        spawnAvailable = checkSpawnSafety();
    }

    public bool checkSpawnSafety()
    {
        List<GameObject> zombies = new List<GameObject>(GameObject.FindGameObjectsWithTag("Zombie"));
        List<GameObject> patients = new List<GameObject>(GameObject.FindGameObjectsWithTag("Patient"));
        List<GameObject> gameObjects = new List<GameObject>();
        gameObjects.AddRange(zombies);
        gameObjects.AddRange(patients);

        Vector3 position = transform.position;
        foreach (GameObject go in gameObjects)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < safeZone)
            {
                return false;
            }
        }
        return true;
    }
}
