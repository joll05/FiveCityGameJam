using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class ScoreDisplay : MonoBehaviour
{
    public string formatting = "{0}";

    TextMeshProUGUI text;

    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        text.text = string.Format(formatting, ScoreManager.Score);

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

