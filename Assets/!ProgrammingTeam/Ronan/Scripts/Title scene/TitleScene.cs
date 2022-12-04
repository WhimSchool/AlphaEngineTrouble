using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TitleScene : MonoBehaviour
{
    public Animator animator;
    Scene currentScene;
    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
    }

    void Update()
    {
        if (currentScene.name == "Title")
        {
            if (Input.anyKeyDown)
            {
                FadeToLevel(1);
            }
        }
    }
    public void  FadeToLevel(int levelIndex)
    {
        animator.SetTrigger("FadeOut");
        
    }
    public void LoadScene()
    {
        SceneManager.LoadScene("Game");
    }
}
