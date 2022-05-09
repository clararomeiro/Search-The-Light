using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public int totalScore;
    public Text scoreText;

    public static GameController instance;

    public GameObject gameOver;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

   public void ShowGameOver()
   {
       gameOver.SetActive(true);
   }

   public void RestartGame(string lvlName)
   {
       SceneManager.LoadScene(lvlName);
   }

   public void UpdateScoreText()
    {
        scoreText.text = totalScore.ToString();
    }
}
