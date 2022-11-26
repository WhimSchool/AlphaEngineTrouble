using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class Pause : MonoBehaviour
{
    public GameObject wristUI;
    public bool activateUI = true;

    public float modifiedTime = 1.5f;

    void Start()
    {
        DisplayUI();
    }

    void Update()
    {
        Time.timeScale = modifiedTime;
    }

    public void PauseButtonPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
            DisplayUI();
    }

    public void DisplayUI()
    {
        if (activateUI)
        {
            wristUI.SetActive(false);
            activateUI = false;
            modifiedTime = 1.5f;
        }

        else if (!activateUI)
        {
            wristUI.SetActive(true);
            activateUI = true;
            modifiedTime = 0;
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
