using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patient : MonoBehaviour
{
    [SerializeField] GameObject[] needs;
    GameObject need;
    // Start is called before the first frame update
    void Start()
    {
        need = needs[Random.Range(0, needs.Length - 1)];
        need.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public GameObject getNeed() {
        return need;
    }

    public void setNeed(GameObject need) {
        this.need = need;
    }
}
