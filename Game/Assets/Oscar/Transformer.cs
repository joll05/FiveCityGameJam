using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transformer : MonoBehaviour
{
    public int Score = 100;
    
    public GameObject state1;
    public GameObject state2;

    bool hit;

    public void OnHit()
    {
        if (hit) return;

        hit = true;

        state1.SetActive(false);
        state2.SetActive(true);
        this.GetComponent<Collider>().enabled = false;
        ScoreManager.ChangeScore(Score);
    }
}
