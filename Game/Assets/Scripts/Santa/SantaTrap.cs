using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SantaTrap : MonoBehaviour
{
    public bool Enabled = true;

    public Material DisabledMat;

    Renderer r;

    bool Activated = false;

    private void Start()
    {
        r = GetComponent<Renderer>();
    }

    private void OnTriggerEnter(Collider other)
    {        
        if (other.CompareTag("Santa") && Enabled)
        {
            SantaController.instance.state = SantaState.Trapped;
            ScoreManager.instance.ComboSpeed = -1f;
            Activated = true;
        }
        else if (other.CompareTag("Projectile"))
        {
            Enabled = false;
            r.material = DisabledMat;
            if (Activated)
            {
                SantaController.instance.state = SantaState.Moving;
                ScoreManager.instance.ComboSpeed = 0.5f;
            }
        }
    }
}
