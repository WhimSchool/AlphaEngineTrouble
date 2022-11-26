using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSystem : MonoBehaviour
{
    public GameObject spawnPoint;
    GameObject player;

    void Start()
    {
        //Set player variable for script interaction
        player = GameObject.FindWithTag("Player");

        //Teleports player to the location of the spawnpoint that is dragged into the inspector script element spawnPoint.
        player.transform.position = spawnPoint.transform.position;
        //Copies spawnpoint rotation
        player.transform.rotation = spawnPoint.transform.rotation;
    }
}
