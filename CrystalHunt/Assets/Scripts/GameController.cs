using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public GameObject gameOver;
    public GameObject gameFinish;
    public Text scoreText;
    public int totalScore;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        gameOver.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowGameOver()
    {
        gameOver.SetActive(true);
        BackgroundSound.instance.StopBackgroundSound();
    }

    public void ShowGameFinish()
    {
        gameFinish.SetActive(true);
        BackgroundSound.instance.StopBackgroundSound();
    }

    public void RestartGame()
    {
        BackgroundSound.instance.StartBackgroundSound();
        SceneManager.LoadScene("SampleScene");

    }

    public void UpdateScoreText()
    {
        scoreText.text = totalScore.ToString();
    }
}
