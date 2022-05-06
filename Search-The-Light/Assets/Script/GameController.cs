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

    [SerializeField]
    private Light2D light;

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
        PlayerPrefs.SetInt("bullet", totalScore);
    }

    public void UpdateLight()
    {
        light.pointLightOuterRadius = 3 + totalScore;
    }
}
