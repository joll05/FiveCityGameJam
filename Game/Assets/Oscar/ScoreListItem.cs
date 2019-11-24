using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreListItem : MonoBehaviour
{
    public string score;
    public string name;

    public int index;

    public TMP_Text t1;
    public TMP_Text t2;
    public TMP_Text t3;

    // Start is called before the first frame update
    void Start()
    {
        t1.text = index.ToString();
        t2.text = name;
        t3.text = score;   
    }
}
