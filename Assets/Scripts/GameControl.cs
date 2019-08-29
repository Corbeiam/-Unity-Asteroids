using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    public GameObject pausePanel;
    private bool pauseActive;


    void Start()
    {
        pausePanel.SetActive(false);
        pauseActive = false;
    }


    void Update()
    {
        if (pauseActive) {
            pausePanel.SetActive(true);
            Time.timeScale = 0;
        } else {
            pausePanel.SetActive(false);
            Time.timeScale = 1;
        }
        
    }

    public void PauseActive() {

        if (pauseActive) {
            pauseActive = false;
        } else {
            pauseActive = true;
        }

    }

    public void Play() {
        SceneManager.LoadScene("Game");
    }

    public void Menu() {
        SceneManager.LoadScene("Menu");
    }

    public void Reboot() {
        SceneManager.LoadScene("Game");
    }
       
    public void Exit() {
        Application.Quit();
    }




}
