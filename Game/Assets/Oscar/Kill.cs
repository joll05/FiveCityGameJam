using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kill : MonoBehaviour
{
    public float time;
    public AudioSource asrc;
    // Start is called before the first frame update
    void Start()
    {
        //Destroy(this.gameObject, time);
        transform.rotation = Random.rotation;
    }
    private void OnCollisionEnter(Collision collision)
    {
        print("hit something");

        if (collision.transform.CompareTag("interactable"))
        {
            collision.transform.GetComponent<Transformer>().OnHit();
        }

        asrc.Play();
    }
}
