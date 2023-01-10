using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSceneLoad : MonoBehaviour
{
    private void Start()
    {
        // if the scene is "Level 1" debug the scene name
        if (SceneManager.GetActiveScene().name == "Level 1")
        {
            // // if floats has value, set it to 0 
            // // retrieve player position from PlayerPrefs
            // PlayerPrefs.DeleteKey("playerX");
            // PlayerPrefs.DeleteKey("playerY");
            
            float x = PlayerPrefs.GetFloat("playerX");
            float y = PlayerPrefs.GetFloat("playerY");

            // move player to position
            transform.position = new Vector2(x, y);
            PlayerPrefs.Save();
        }
        PlayerPrefs.DeleteKey("playerX");
        PlayerPrefs.DeleteKey("playerY");
    }
}
