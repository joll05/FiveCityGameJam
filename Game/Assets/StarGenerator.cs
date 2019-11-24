using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarGenerator : MonoBehaviour
{
    public int Count = 30;

    public GameObject star;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < Count; i++)
        {
            Vector3 position = new Vector3(Random.Range(-20, 20), Random.Range(-20, 20), Random.Range(-20, 20));
            Instantiate(star, position, Quaternion.identity);
        }

        Destroy(gameObject);
    }
}
