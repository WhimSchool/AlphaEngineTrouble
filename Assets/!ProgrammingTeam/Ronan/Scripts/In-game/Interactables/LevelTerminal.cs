using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelTerminal : MonoBehaviour
{
    public Camera playerCam;
    public GameObject cardSpawnPoint;
    public GameObject[] cardPrefabs;

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out hit, 1.5f))
        {
            if (hit.transform.name == "level1" && Input.GetMouseButtonDown(0))
            {
                Instantiate(cardPrefabs[0], cardSpawnPoint.transform.position, cardSpawnPoint.transform.rotation);
            }
            else if (hit.transform.name == "level2" && Input.GetMouseButtonDown(0))
            {
                Instantiate(cardPrefabs[1], cardSpawnPoint.transform.position, cardSpawnPoint.transform.rotation);
            }
        }
    }
}
// CursorLockMode.Locked doesn't work with world space UI/button. Had to use raycast.
// If this doesn't work in VR then maybe try OnCollisionEnter to detech player's hand since the buttons have box collision.
