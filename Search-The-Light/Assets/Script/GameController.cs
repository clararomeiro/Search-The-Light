using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Experimental.Rendering.Universal;

public class GameController : MonoBehaviour
{

    public int totalMunition;
    public Text munitionText;
    public int totalScore;
    public Text scoreText;

    public static GameController instance;

    public GameObject gameOver;

    public BoxCollider2D nextLevelTrigger;
    public BoxCollider2D endLevelTrigger;

    [SerializeField]
    private Light2D light;

    private float lightRadius;

    private bool isPaused;
    public GameObject pausePanel;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        Time.timeScale = 1;
    }

    void Update ()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            PauseScreen();
        }
    }

    public void PauseScreen()
    {
        if(isPaused)
        {
            isPaused = false;
            Time.timeScale = 1f;
            pausePanel.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            isPaused = true;
            Time.timeScale = 0f;
            pausePanel.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        } 
    }

    public void QuitGame()
    {
        //Editor Unity
        //UnityEditor.EditorApplication.isPlaying = false;
        //Jogo Compilado
        Application.Quit();
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
        lightRadius = totalMunition;
    }

    public void UpdateScoreText()
    {
        scoreText.text = totalScore.ToString();
    }

    public void UpdateLight()
    {
        light.pointLightOuterRadius = 4 + (lightRadius/2);
    }

    public void UpdateLightLantern(bool ison)
    {
        if (ison)
        {
            light.pointLightOuterRadius = 10;

        }
        else
        {
            light.pointLightOuterRadius = 4 + (lightRadius / 2);
        }
    }

}
