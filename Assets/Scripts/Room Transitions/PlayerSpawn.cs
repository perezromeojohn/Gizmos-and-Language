using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSpawn : MonoBehaviour
{
    public string[] sceneNames;
    public Vector3[] spawnPositions;
    private int spawnIndex;

    void Start()
    {
        // Get the current scene name
        string currentSceneName = SceneManager.GetActiveScene().name;

        // Find the index of the current scene name in the sceneNames array
        for (int i = 0; i < sceneNames.Length; i++)
        {
            if (currentSceneName == sceneNames[i])
            {
                spawnIndex = i;
                break;
            }
        }

        // Spawn the player at the corresponding position
        transform.position = spawnPositions[spawnIndex];
    }
}
