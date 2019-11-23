using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public float lvl;
    GameObject cameraMain;
    public static Camera current;
    CameraScript cameraScript;

    // Start is called before the first frame update
    void Start()
    {
        cameraScript = Camera.main.gameObject.GetComponent<CameraScript>();
        current = Camera.main;
        
    }

    // Update is called once per frame
    void Update()
    {

        if (cameraScript.currentLvl == lvl)
        {
            this.gameObject.SetActive(true);
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }
}
