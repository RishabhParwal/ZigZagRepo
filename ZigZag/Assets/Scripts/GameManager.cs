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
        this.GetComponent<CameraFollowAJ>().enabled = false;
        if (PlayerPrefs.GetString("Character") == null)
        {
            PlayerPrefs.SetString("Character", "James");
        }
        if (PlayerPrefs.GetString("Character") == "James")
        {
            UiManager.instance.AJ.SetActive(false);
            UiManager.instance.james.SetActive(true);
        }
        if (PlayerPrefs.GetString("Character") == "AJ")
        {
            UiManager.instance.james.SetActive(false);
            UiManager.instance.AJ.SetActive(true);
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
        UiManager.instance.Character();
    }

    public void James()
    {
        PlayerPrefs.SetString("Character", "James");
        Camera.main.GetComponent<CameraFollowAJ>().enabled = false;
        Camera.main.GetComponent<CameraFollowJames>().enabled = true;
        UiManager.instance.Character();
    }
}
