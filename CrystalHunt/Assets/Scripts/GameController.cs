using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public GameObject gameOver;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
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

    public void RestartGame()
    {
        BackgroundSound.instance.StartBackgroundSound();
        SceneManager.LoadScene("SampleScene");

    }
}
