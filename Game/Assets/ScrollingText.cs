using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingText : MonoBehaviour
{
    public float Scrollspeed = 100;

    void Update()
    {
        transform.Translate(0, Scrollspeed * Time.deltaTime, 0);
    }
}
