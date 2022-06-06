using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreCalculator : MonoBehaviour
{
    [SerializeField]
    private bool autoUpdate = false;

    [SerializeField]
    private string scoreText;

    void Start()
    {
        SetScoreText();
    }

    void Update()
    {
        if (autoUpdate)
            SetScoreText();
    }

    void SetScoreText()
    {
        GetComponent<TMP_Text>().text = string.Format(scoreText, GetCurrentScore());
    }

    public static int GetCurrentScore()
    {
        return Mathf.RoundToInt(((float) AudioManager.latestTimeSample / (float) AudioManager.maxSamples) * 100);
    }
}
