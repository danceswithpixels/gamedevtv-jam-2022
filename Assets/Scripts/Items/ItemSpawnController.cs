using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawnController : MonoBehaviour
{
    [SerializeField] int maxDuplicates = 1;
    [SerializeField] GameObject[] items;
    GameObject[] itemSpawns;
    Dictionary<string, GameObject> tagToItemMap;

    void Start()
    {
        itemSpawns = GameObject.FindGameObjectsWithTag("iSpawn");
        tagToItemMap = new Dictionary<string, GameObject>();
        foreach (GameObject item in items) {
            tagToItemMap.Add(item.tag, item);
        }
    }

    void Update()
    {
        spawnItems();
    }

    void spawnItems() {
        List<GameObject> spawns = new List<GameObject>(itemSpawns);
        List<GameObject> availableSpawns = new List<GameObject>();

        // Remove spawns from availableSpawns which already have items on them
        foreach (GameObject spawn in spawns) {
            if (spawn.GetComponent<ItemSpawn>().spawnAvailable) {
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
