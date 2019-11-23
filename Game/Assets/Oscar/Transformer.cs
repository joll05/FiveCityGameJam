using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transformer : MonoBehaviour
{
    public GameObject state1;
    public GameObject state2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnHit()
    {
        state1.SetActive(false);
        state2.SetActive(true);
    }
}
