using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patient : MonoBehaviour
{
    [SerializeField] GameObject[] needs;
    GameObject need;
    int numNeeds;
    
    void Awake() {
        numNeeds = Random.Range(1,4);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (need == null && numNeeds > 0) {
            need = needs[Random.Range(0, needs.Length)];
            need.SetActive(true);
        }
    }
    
    public GameObject getNeed() {
        return need;
    }

    public void resetNeed() {
        numNeeds--;
        if (need != null) {
            need.SetActive(false);
            need = null;
        }
    }

    public int getNumNeeds() {
        return numNeeds;
    }
}
