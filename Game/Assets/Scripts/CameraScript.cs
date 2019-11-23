using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public float sensetivity;
    public Vector3 startPos;
    public Quaternion startRot;
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
        startRot = this.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(start.position);
        if (inOffice)
        {
            transform.RotateAround(transform.position, new Vector3(0, 1, 0), Input.GetAxis("Mouse X") * sensetivity);
            transform.RotateAround(transform.position, this.transform.right, Input.GetAxis("Mouse Y") * sensetivity * -1);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.transform.position = startPos;
            this.transform.rotation = startRot;
            Cursor.lockState = CursorLockMode.Locked;
            inOffice = true;
            inOffice = true;
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