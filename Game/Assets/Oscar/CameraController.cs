using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static Camera current;

    // Start is called before the first frame update
    void Start()
    {
        current = Camera.main;   
    }
}
