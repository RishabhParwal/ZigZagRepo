using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public int score;
    public int highScore;
    public int diamondCount;
    public int totalDiamonds;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        score = 0;
        PlayerPrefs.SetInt("score", score);
        PlayerPrefs.SetInt("diamonds", diamondCount);
        totalDiamonds = PlayerPrefs.GetInt("totalDiamonds");
    }

    void Update()
    {
        PlayerPrefs.SetInt("score", score);
        PlayerPrefs.SetInt("diamonds", diamondCount);

        if (PlayerPrefs.HasKey("highScore"))
        {
            if (score > PlayerPrefs.GetInt("highScore"))
            {
                PlayerPrefs.SetInt("highScore", score);
            }
        }
        else
        {
            PlayerPrefs.SetInt("highScore", score);
        }

        if (PlayerPrefs.HasKey("totalDiamonds"))
        {
            PlayerPrefs.SetInt("totalDiamonds", totalDiamonds + diamondCount);
        }
        else
        {
            PlayerPrefs.SetInt("totalDiamonds", diamondCount);
        }
    }

    void IncrementScore()
    {
        score += 1;
    }

    public void StartScore()
    {
        InvokeRepeating("IncrementScore", 0.1f, 0.5f);
    }

    public void StopScore()
    {
        CancelInvoke("IncrementScore");
        PlayerPrefs.SetInt("score", score);
        PlayerPrefs.SetInt("diamonds", diamondCount);

        if (PlayerPrefs.HasKey("highScore"))
        {
            if (score > PlayerPrefs.GetInt("highScore"))
            {
                PlayerPrefs.SetInt("highScore", score);
            }
        }
        else
        {
            PlayerPrefs.SetInt("highScore", score);
        }

        if (PlayerPrefs.HasKey("totalDiamonds"))
        {
            PlayerPrefs.SetInt("totalDiamonds", totalDiamonds + diamondCount);
        }
        else
        {
            PlayerPrefs.SetInt("totalDiamonds", diamondCount);
        }
    }
}
