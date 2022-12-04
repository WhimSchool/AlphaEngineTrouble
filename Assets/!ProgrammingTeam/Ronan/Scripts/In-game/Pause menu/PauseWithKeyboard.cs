using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseWithKeyboard : MonoBehaviour
{
    public GameObject pauseCanvas;

    public void Update()
    {
        if (Input.GetKeyDown("f"))
        {
            Time.timeScale = 0f;
            AudioListener.pause = true;
            pauseCanvas.SetActive(true);
            Cursor.lockState = CursorLockMode.None; //Doesn't work with standard asset FPS controller
            Cursor.visible = true;
        }
    }
}

/*Notes:
 * Stop object from blinking and hand crosshair from appearing while in pause menu when mouse is over the object.
 */