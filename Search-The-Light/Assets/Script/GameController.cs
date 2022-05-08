using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Experimental.Rendering.Universal;

public class GameController : MonoBehaviour
{

    public int totalScore;
    public Text scoreText;

    public static GameController instance;

    public GameObject gameOver;

    public BoxCollider2D nextLevelTrigger;
    public BoxCollider2D endLevelTrigger;

    [SerializeField]
    private Light2D light;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        Time.timeScale = 1;
    }

    public void ShowGameOver()
    {
        gameOver.SetActive(true);
        Time.timeScale = 0;
    }

    public void RestartGame(string lvlName)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(lvlName);
    }

    public void UpdateScoreText()
    {
        scoreText.text = totalScore.ToString();
        PlayerPrefs.SetInt("bullet", totalScore);
    }

    public void UpdateLight()
    {
        light.pointLightOuterRadius = 3 + (totalScore/2);
    }

}
