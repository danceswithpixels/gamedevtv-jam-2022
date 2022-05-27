using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class ZombieAI : MonoBehaviour
{
    AIPath aiPath;

    void Awake() {
        aiPath = GetComponent<AIPath>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        aiPath.destination = FindClosestEnemy().transform.position;
    }

    public GameObject FindClosestEnemy()
    {
        List<GameObject> gameObjects = new List<GameObject>(GameObject.FindGameObjectsWithTag("Patient"));
        gameObjects.Add(GameObject.FindGameObjectWithTag("Player"));

        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gameObjects)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }
}
