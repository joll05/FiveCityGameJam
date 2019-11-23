using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SantaTrap : MonoBehaviour
{
    public bool Enabled = true;

    bool Activated = false;

    private void OnTriggerEnter(Collider other)
    {        
        if (other.CompareTag("Santa") && Enabled)
        {
            SantaController.instance.state = SantaState.Trapped;
            Activated = true;
        }
        else if (other.CompareTag("Projectile"))
        {
            Enabled = false;
            if (Activated)
            {
                SantaController.instance.state = SantaState.Moving;
            }
        }
    }
}
