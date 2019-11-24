using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public float sensetivity;
    public Vector3 startPos;
    public Quaternion startRot;
    public int currentLvl;
    public int back;
    public bool inOffice = true;

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

        if (Input.GetKeyDown(KeyCode.Space) || currentLvl != back)
        {
            if(currentLvl < 4) 
            { 
                back = currentLvl;
                this.transform.position = startPos;
                this.transform.rotation = startRot;
                Cursor.lockState = CursorLockMode.Locked;
                inOffice = true;
                inOffice = true;
            }
        }
    }
}