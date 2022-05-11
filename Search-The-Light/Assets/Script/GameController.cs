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

    public int totalMunition;
    public Text munitionText;

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

    public void UpdateMunitionText()
    {
        munitionText.text = totalMunition.ToString();
        PlayerPrefs.SetInt("bullet", totalMunition);
    }

    public void UpdateScoreText()
    {
        scoreText.text = totalScore.ToString();
    }


    public void UpdateLight()
    {
        light.pointLightOuterRadius = 3 + (totalMunition/2);
    }

}
