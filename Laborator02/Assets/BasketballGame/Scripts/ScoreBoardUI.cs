using UnityEngine;
using TMPro;

public class ScoreboardUI : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private TMP_Text scoreText;

    private int totalScore = 0;

    private void Start()
    {
        UpdateDisplay();
    }

    public void AddPoints(int points)
    {
        totalScore += points;
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        if (scoreText != null)
        {
            scoreText.text = $"Score: {totalScore}";
        }
    }
}