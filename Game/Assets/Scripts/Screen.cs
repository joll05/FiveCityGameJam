using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screen : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject screenCamera;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseDown()
    {
        mainCamera.transform.position = screenCamera.transform.position;
        mainCamera.transform.rotation = screenCamera.transform.rotation;
    }
}
