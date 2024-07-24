using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public int score;
    public TMP_Text scoreText;  

    public GameObject bkg1, bkg2, bkg3, bkg4, bkg5;
    //public GameObject nextBackground;

    public int pointsToChange = 10;

    //private bool changedBackground = false;

    private GameController gameController;

    public TMP_Text highscoreText;

    public GameObject gameOver;

    public AudioManager audioManager;

    void Awake()
    {
        Time.timeScale = 1;
        gameController = FindObjectOfType<GameController>();
    }

    void Update()
    {
        ChangeBackgroundAndMusic();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

   public void ShowGameOver()
   {
        gameOver.SetActive(true);        
        Time.timeScale = 0;  

        //YourScoreText.text = "Your Score: " + score;      

        if(score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", (int)score);
        }

        highscoreText.text = "HIGHSCORE: " + PlayerPrefs.GetInt("HighScore");
   }

   public void ChangeBackgroundAndMusic()
   {
      if(gameController.score == 15)
      {
        bkg1.SetActive(false);
        bkg2.SetActive(true);
        //audioManager.PlayMusic2();
      }

      if(gameController.score == 30)
      {
        bkg2.SetActive(false);
        bkg3.SetActive(true);
        //audioManager.PlayMusic2();
      }

      if(gameController.score == 50)
      {
        bkg3.SetActive(false);
        bkg4.SetActive(true);
        //audioManager.PlayMusic2();
      }

      if(gameController.score == 70)
      {
        bkg4.SetActive(false);
        bkg5.SetActive(true);
        //audioManager.PlayMusic2();
      }
   }

}
