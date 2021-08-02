using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool gameOver;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        if (PlayerPrefs.GetString("Character") == null)
        {
            PlayerPrefs.SetString("Character", "AJ");
            UiManager.instance.james.SetActive(false);
            UiManager.instance.AJ.SetActive(true);
            UiManager.instance.remy.SetActive(false);
        }
        else if (PlayerPrefs.GetString("Character") == "James")
        {
            UiManager.instance.AJ.SetActive(false);
            UiManager.instance.james.SetActive(true);
            UiManager.instance.remy.SetActive(false);
        }
        else if (PlayerPrefs.GetString("Character") == "AJ")
        {
            UiManager.instance.james.SetActive(false);
            UiManager.instance.AJ.SetActive(true);
            UiManager.instance.remy.SetActive(false);
        }
        else if (PlayerPrefs.GetString("Character") == "Remy")
        {
            UiManager.instance.james.SetActive(false);
            UiManager.instance.AJ.SetActive(false);
            UiManager.instance.remy.SetActive(true);
        }
        UiManager.instance.Character();
        gameOver = false;
    }

    void Update()
    {

    }

    public void StartGame()
    {
        UiManager.instance.GameStart();
        ScoreManager.instance.StartScore();
        GameObject.Find("PlatformSpawner").GetComponent<PlatformSwaner>().StartSpawningPlatforms();
    }

    public void GameOver()
    {
        UiManager.instance.GameOver();
        ScoreManager.instance.StopScore();
        gameOver = true;
    }

    public void AJ()
    {
        PlayerPrefs.SetString("Character", "AJ");
        Camera.main.GetComponent<CameraFollowJames>().enabled = false;
        Camera.main.GetComponent<CameraFollowAJ>().enabled = true;
        Camera.main.GetComponent<CameraFollowRemy>().enabled = false;
        UiManager.instance.Character();
    }

    public void James()
    {
        if (PlayerPrefs.GetString("James") == "Unlocked")
        {
            PlayerPrefs.SetString("Character", "James");
            Camera.main.GetComponent<CameraFollowAJ>().enabled = false;
            Camera.main.GetComponent<CameraFollowJames>().enabled = true;
            Camera.main.GetComponent<CameraFollowRemy>().enabled = false;
            UiManager.instance.Character();
        }
    }

    public void Remy()
    {
        if (PlayerPrefs.GetString("Remy") == "Unlocked")
        {
            PlayerPrefs.SetString("Character", "Remy");
            Camera.main.GetComponent<CameraFollowAJ>().enabled = false;
            Camera.main.GetComponent<CameraFollowJames>().enabled = false;
            Camera.main.GetComponent<CameraFollowRemy>().enabled = true;
            UiManager.instance.Character();
        }
    }

    public void UnlockJames()
    {
        if (PlayerPrefs.GetInt("totalDiamonds") >= 500)
        {
            UiManager.instance.JamesUnlocked();
        }
        else
        {
            Debug.Log("not enough diamonds");
        }
    }

    public void UnlockRemy()
    {
        if (PlayerPrefs.GetInt("totalDiamonds") >= 500)
        {
            UiManager.instance.RemyUnlocked();
        }
        else
        {
            Debug.Log("not enough diamonds");
        }
    }
}
