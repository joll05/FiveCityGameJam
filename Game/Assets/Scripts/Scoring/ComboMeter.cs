using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class ComboMeter : MonoBehaviour
{
    public Graphic fill;
    
    Slider slider;

    void Start()
    {
        slider = GetComponent<Slider>();
    }
    void Update()
    {
        slider.value = ScoreManager.ComboProgression;

        if (ScoreManager.IncreasingCombo)
        {            
            fill.color = ScoreManager.goodColor;            
        }
        else
        {
            fill.color = ScoreManager.badColor;
        }
    }
}
