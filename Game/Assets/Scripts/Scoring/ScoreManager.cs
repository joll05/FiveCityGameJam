using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static float Score = 0;
    public static int Combo = 1;

    public float ComboSpeed = 1;

    public int MaxCombo = 99;

    public static float ComboProgression = 0;

    void Update()
    {
        ComboProgression += ComboSpeed * Time.deltaTime;

        if(ComboProgression > 1)
        {
            if (Combo < MaxCombo)
            {
                Combo++;
                ComboProgression--;
            }
            else
            {
                ComboProgression = 1;
            }
        }
        else if(ComboProgression < 0)
        {
            if (Combo > 1)
            {
                Combo--;
                ComboProgression++;
            }
            else
            {
                ComboProgression = 0;
            }
        }
    }
}
