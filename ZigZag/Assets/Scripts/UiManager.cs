using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    public static UiManager instance;

    public GameObject zigzagPanel;
    public GameObject gameOverPanel;
    public GameObject tapText;
    public GameObject viewScoreCanvas;
    public GameObject AJ;
    public GameObject james;
    public GameObject shop;
    public Text viewScore;
    public Text viewDiamondCount;
    public Text diamondCount;
    public Text mainDiamondCount;
    public Text score;
    public Text highScore1;
    public Text highScore2;
    public Text characterSelected;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        if (PlayerPrefs.GetString("Character") == "James")
        {
            AJ.SetActive(false);
            james.SetActive(true);
            characterSelected.text = "Character Selected: James";
        }
        if (PlayerPrefs.GetString("Character") == "AJ")
        {
            james.SetActive(false);
            AJ.SetActive(true);
            characterSelected.text = "Character Selected: AJ";
        }
        highScore1.text = "High Score: " + PlayerPrefs.GetInt("highScore");
        mainDiamondCount.text = "Diamonds: " + PlayerPrefs.GetInt("totalDiamonds");
    }

    public void GameStart()
    {
        tapText.SetActive(false);
        zigzagPanel.SetActive(false);
        viewScoreCanvas.SetActive(true);
    }

    public void GameOver()
    {
        score.text = PlayerPrefs.GetInt("score").ToString();
        diamondCount.text = PlayerPrefs.GetInt("totalDiamonds").ToString();
        highScore2.text = PlayerPrefs.GetInt("highScore").ToString();
        gameOverPanel.SetActive(true);
        viewScoreCanvas.SetActive(false);
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    void Update()
    {
        viewScore.text = "Score: " + PlayerPrefs.GetInt("score");
        viewDiamondCount.text = "Diamonds: " + PlayerPrefs.GetInt("totalDiamonds");
    }

    public void OpenShop()
    {
        shop.SetActive(true);
    }

    public void ExitShop()
    {
        shop.SetActive(false);
    }

    public void Character()
    {
        characterSelected.text = "Character Selected: " + PlayerPrefs.GetString("Character");
        if (PlayerPrefs.GetString("Character") == "AJ")
        {
            AJ.SetActive(true);
            james.SetActive(false);
        }
        else if (PlayerPrefs.GetString("Character") == "James")
        {
            james.SetActive(true);
            AJ.SetActive(false);
        }
    }

    public void GameStarted()
    {
        JamesController.instance.Started();
        AJController.instance.Started();
    }
}
