using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class ComboDisplay : MonoBehaviour
{
    public string formatting = "x{0}";
    
    TextMeshProUGUI text;

    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        text.text = string.Format(formatting, ScoreManager.Combo);

        if (ScoreManager.IncreasingCombo)
        {
            text.color = ScoreManager.goodColor;
        }
        else
        {
            text.color = ScoreManager.badColor;
        }
    }
}
