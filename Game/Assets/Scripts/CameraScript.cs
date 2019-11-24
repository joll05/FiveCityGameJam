using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public float sensetivity;
<<<<<<< Updated upstream
    Vector3 startPos;
    Vector3 startRot;
=======
    public Vector3 startPos;
    public Quaternion startRot;
    public int currentLvl;
    int back;
    public bool inOffice = true;

>>>>>>> Stashed changes
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        startPos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(transform.position, new Vector3(0, 1, 0), Input.GetAxis("Mouse X") * sensetivity);
        transform.RotateAround(transform.position, this.transform.right, Input.GetAxis("Mouse Y") * sensetivity * -1);

        if (Input.GetKeyDown(KeyCode.Space) || currentLvl != back)
        {
<<<<<<< Updated upstream
<<<<<<< Updated upstream
            this.transform.position = startPos;
            this.transform.position = startPos;
=======
=======
>>>>>>> Stashed changes
            if (currentLvl < 4)
            {
                back = currentLvl;
                this.transform.position = startPos;
                this.transform.rotation = startRot;
                Cursor.lockState = CursorLockMode.Locked;
                inOffice = true;
                inOffice = true;
            }
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
        }
    }
}

