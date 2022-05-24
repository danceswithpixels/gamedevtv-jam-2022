using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patient : MonoBehaviour
{
    [SerializeField] GameObject[] needs;
    GameObject need;
    int numNeeds;
    // Start is called before the first frame update
    void Start()
    {
        numNeeds = Random.Range(1,3);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && numNeeds > 0) {
            resetNeed();
        }
        
        if (need == null && numNeeds > 0) {
            need = needs[Random.Range(0, needs.Length - 1)];
            need.SetActive(true);
        }
    }
    
    public GameObject getNeed() {
        return need;
    }

    public void resetNeed() {
        numNeeds--;
        need.SetActive(false);
        need = null;
    }

    public int getNumNeeds() {
        return numNeeds;
    }
}
