using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Throw : MonoBehaviour
{
    public GameObject go;
    public float baseForce;
    public float maxtime = 5.5f;
    public float multiplier = 10;
    float timer;
    bool startTime;

    public Slider forceSlider;
    public Vector3 sliderOffset;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        forceSlider.value = timer / maxtime;
        print(timer / maxtime);
        if (Input.GetMouseButtonDown(0))
        {
            startTime = true;
            forceSlider.transform.position = Input.mousePosition + sliderOffset;
            forceSlider.gameObject.SetActive(true);
        }


        if (Input.GetMouseButtonUp(0))
        {
            Vector3 input = new Vector3(Input.mousePosition.x, Input.mousePosition.y);
            Ray r = CameraController.current.ScreenPointToRay(input);
            Debug.DrawRay(r.origin, r.direction * 100, Color.blue, 12);
            //print(CameraController.current);
            GameObject instance = Instantiate(go) as GameObject;
            instance.transform.position = CameraController.current.transform.position;
            instance.GetComponent<Rigidbody>().AddForce(r.direction * (baseForce + multiplier * timer), ForceMode.Impulse);
            print(timer);
            startTime = false;
            timer = 0;
            forceSlider.gameObject.SetActive(false);
        }

        if(startTime)
        {
            timer = ((timer + Time.deltaTime) < maxtime) ? timer + Time.deltaTime : maxtime;
        }
    }
}
