using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Audio;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject GameOverScreen;
    [SerializeField] private GameObject WinScene;
    [SerializeField] private TMP_Text LifeText;

    public float delayBeforeGameOver = 1f;




    public static GameManager Instance { get; private set; }


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

    }

    void Update()
    {

    }




    public void ShowGameOverScreen()
    {
        Invoke("ShowGameOver", delayBeforeGameOver);
    }

    private void ShowGameOver()
    {
        GameOverScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    public void WinScreen()
    {
        WinScene.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }



}