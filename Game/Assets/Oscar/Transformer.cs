using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transformer : MonoBehaviour
{
    public int Score = 100;
    
    public GameObject state1;
    public GameObject state2;

    public void OnHit()
    {
        print("hit");
        state1.SetActive(false);
        state2.SetActive(true);

        ScoreManager.ChangeScore(Score);
    }
}
