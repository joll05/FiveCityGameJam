using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Quits the player when the user hits escape

public class EscapeToQuit : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
}