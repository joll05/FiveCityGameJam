using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{
    public GameObject go;
    public float intensity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 input = new Vector3(Input.mousePosition.x, Input.mousePosition.y);
            Ray r = CameraController.current.ScreenPointToRay(input);
            Debug.DrawRay(r.origin, r.direction * 100, Color.blue, 12);
            //print(CameraController.current);
            GameObject instance = Instantiate(go) as GameObject;
            instance.transform.position = CameraController.current.transform.position;
            instance.GetComponent<Rigidbody>().AddForce(r.direction * intensity, ForceMode.Impulse);
        }
    }
}
