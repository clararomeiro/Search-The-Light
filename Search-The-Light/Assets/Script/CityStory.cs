using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CityStory : MonoBehaviour
{
    void OnEnable()
    {
        SceneManager.LoadScene("Game2", LoadSceneMode.Single);
    }
}
