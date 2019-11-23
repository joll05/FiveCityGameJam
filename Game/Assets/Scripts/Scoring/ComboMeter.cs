using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class ComboMeter : MonoBehaviour
{
    Slider slider;

    void Start()
    {
        slider = GetComponent<Slider>();
    }
    void Update()
    {
        slider.value = ScoreManager.ComboProgression;
    }
}
