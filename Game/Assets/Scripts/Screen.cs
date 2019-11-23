using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screen : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject screenCamera;
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

    }
    void OnMouseDown()
    {
        cameraScript.startPos = Camera.main.transform.position;
        cameraScript.startRot = Camera.main.transform.rotation;
        Cursor.lockState = CursorLockMode.None;
        cameraScript.inOffice = false;
        mainCamera.transform.position = screenCamera.transform.position;
        mainCamera.transform.rotation = screenCamera.transform.rotation;
        StartCoroutine(Throw.ToggleThrowing(0.05f, true));
    }
}