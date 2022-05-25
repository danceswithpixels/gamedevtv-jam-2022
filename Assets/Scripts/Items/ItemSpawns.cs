using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawns : MonoBehaviour
{
    [SerializeField] int maxDuplicates = 1;
    [SerializeField] GameObject[] items;
    GameObject[] spawnTrays;
    Dictionary<string, GameObject> tagToItemMap;

    // Start is called before the first frame update
    void Start()
    {
        spawnTrays = GameObject.FindGameObjectsWithTag("Spawn");
        tagToItemMap = new Dictionary<string, GameObject>();
        foreach (GameObject item in items) {
            tagToItemMap.Add(item.tag, item);
        }
    }

    // Update is called once per frame
    void Update()
    {
        spawnItems();
    }

    void spawnItems() {
        List<GameObject> spawns = new List<GameObject>(spawnTrays);
        List<GameObject> availableSpawns = new List<GameObject>();

        Debug.Log(spawns.Count);

        // Remove spawns from availableSpawns which already have items on them
        foreach (GameObject spawn in spawns) {
            if (spawn.GetComponent<Spawn>().spawnAvailable) {
                availableSpawns.Add(spawn);
            }
        }

        // For each item, instantiate another if count is less than maxDuplicates
        // Instantiate on one of the remaining availableSpawns
        // Remove selected spawn from availableSpawns for subsequent item spawns
        foreach (GameObject item in items) {
            while (availableSpawns.Count > 0 && GameObject.FindGameObjectsWithTag(item.tag).Length < maxDuplicates) {
                GameObject spawn = availableSpawns[Random.Range(0, availableSpawns.Count)];
                Instantiate(tagToItemMap[item.tag], spawn.transform.position, transform.rotation);
                availableSpawns.Remove(spawn);
            }
        }
    }
}
