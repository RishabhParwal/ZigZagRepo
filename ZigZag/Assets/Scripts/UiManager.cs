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
    public GameObject remy;
    public GameObject shop;
    public GameObject jamesUnlock;
    public GameObject remyUnlock;
    public Text viewScore;
    public Text viewDiamondCount;
    public Text diamondCount;
    public Text mainDiamondCount;
    public Text shopDiamondCount;
    public Text score;
    public Text highScore1;
    public Text highScore2;
    public Text characterSelected;
    public Text jamesLock;
    public Text jamesPrice;
    public Text remyLock;
    public Text remyPrice;

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
            remy.SetActive(false);
            characterSelected.text = "Character Selected: James";
        }
        if (PlayerPrefs.GetString("Character") == "AJ")
        {
            james.SetActive(false);
            AJ.SetActive(true);
            remy.SetActive(false);
            characterSelected.text = "Character Selected: AJ";
        }
        if (PlayerPrefs.GetString("Character") == "Remy")
        {
            james.SetActive(false);
            remy.SetActive(true);
            AJ.SetActive(false);
            characterSelected.text = "Character Selected: Remy";
        }
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
        shopDiamondCount.text = "Diamonds: " + PlayerPrefs.GetInt("totalDiamonds");
        highScore1.text = "High Score: " + PlayerPrefs.GetInt("highScore");
        mainDiamondCount.text = "Diamonds: " + PlayerPrefs.GetInt("totalDiamonds");
        if (PlayerPrefs.GetString("James") == "Unlocked")
        {
            jamesPrice.text = "";
            jamesLock.text = "UNLOCKED";
            jamesUnlock.SetActive(false);
        }
        if (PlayerPrefs.GetString("Remy") == "Unlocked")
        {
            remyPrice.text = "";
            remyLock.text = "UNLOCKED";
            remyUnlock.SetActive(false);
        }
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
        if (PlayerPrefs.GetString("Character") == null)
        {
            PlayerPrefs.SetString("Character", "AJ");
        }
        characterSelected.text = "Character Selected: " + PlayerPrefs.GetString("Character");
        if (PlayerPrefs.GetString("Character") == "AJ")
        {
            AJ.SetActive(true);
            james.SetActive(false);
            remy.SetActive(false);
        }
        else if (PlayerPrefs.GetString("Character") == "James")
        {
            james.SetActive(true);
            AJ.SetActive(false);
            remy.SetActive(false);
        }
        else if (PlayerPrefs.GetString("Character") == "Remy")
        {
            remy.SetActive(true);
            AJ.SetActive(false);
            james.SetActive(false);
        }
    }

    public void GameStarted()
    {
        if (PlayerPrefs.GetString("Character") == "James")
        {
            JamesController.instance.Started();
        }
        else if (PlayerPrefs.GetString("Character") == "AJ")
        {
            AJController.instance.Started();
        }
        else if (PlayerPrefs.GetString("Character") == "Remy")
        {
            RemyController.instance.Started();
        }
        else if (PlayerPrefs.GetString("Character") == null)
        {
            PlayerPrefs.SetString("Character", "AJ");
            AJController.instance.Started();
        }
    }

    public void JamesUnlocked()
    {
        PlayerPrefs.SetString("James", "Unlocked");
        // PlayerPrefs.SetInt("totalDiamonds", PlayerPrefs.GetInt("totalDiamonds") - 500);
        ScoreManager.instance.totalDiamonds = ScoreManager.instance.totalDiamonds - 500;
        jamesLock.text = "UNLOCKED";
        jamesUnlock.SetActive(false);
    }

    public void RemyUnlocked()
    {
        PlayerPrefs.SetString("Remy", "Unlocked");
        // PlayerPrefs.SetInt("totalDiamonds", PlayerPrefs.GetInt("totalDiamonds") - 500);
        ScoreManager.instance.totalDiamonds = ScoreManager.instance.totalDiamonds - 500;
        remyLock.text = "UNLOCKED";
        remyUnlock.SetActive(false);
    }
}
