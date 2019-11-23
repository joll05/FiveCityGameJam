using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public float sensetivity;
    Vector3 startPos;
    Vector3 startRot;
    public float currentLvl;
    public bool inOffice = true;

    public GameObject lvl_1;
    public GameObject lvl_2;
    public GameObject lvl_3;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        startPos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (inOffice)
        {
            transform.RotateAround(transform.position, new Vector3(0, 1, 0), Input.GetAxis("Mouse X") * sensetivity);
            transform.RotateAround(transform.position, this.transform.right, Input.GetAxis("Mouse Y") * sensetivity * -1);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.transform.position = startPos;
            this.transform.position = startPos;
            Cursor.lockState = CursorLockMode.Locked;
            inOffice = true;
            StartCoroutine(Throw.ToggleThrowing(0.25f, false));
        }

        //santa goes to the next room
        if (Input.GetKeyDown(KeyCode.I))
        {
            currentLvl += 1;
            
            if (currentLvl == 2)
            {
                lvl_1.SetActive(false);
                lvl_2.SetActive(true);
            }
            if (currentLvl == 3)
            {
                lvl_2.SetActive(false);
                lvl_3.SetActive(true);
            }

        }
    }
}

