using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    private static bool _isPaused = false;
    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private GameObject fpsController;
    [SerializeField] private GameObject fpsCamera;
    [SerializeField] private SaveLoadData saveLoadData;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    
    private void ShowCursor(bool show)
    {
        Cursor.visible = show;
        Cursor.lockState = show ? CursorLockMode.None : CursorLockMode.Locked;
    }

    public void Resume()
    {
        fpsCamera.GetComponent<FirstPersonLook>().enabled = true;
        fpsCamera.GetComponent<PickUpObject>().enabled = true;
        fpsController.GetComponent<PlayerInteraction>().enabled = true;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        _isPaused = false;
        ShowCursor(false);
    }

    private void Pause()
    {
        fpsCamera.GetComponent<FirstPersonLook>().enabled = false;
        fpsCamera.GetComponent<PickUpObject>().enabled = false;
        fpsController.GetComponent<PlayerInteraction>().enabled = false;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        _isPaused = true;
        ShowCursor(true);
    }

    public void ExitGame()
    {
        Environment.Exit(0);
        //SceneManager.LoadScene("mainScene");
    }

    public void ExitGameFromSceneOne()
    {
        saveLoadData.SaveData();
        
        Environment.Exit(0);
    }
}