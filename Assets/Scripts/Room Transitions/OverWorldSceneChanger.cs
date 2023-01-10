using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OverWorldSceneChanger : MonoBehaviour
{
    public Vector2 position; // position to move player to in next scene
    public string sceneName; // name of next scene to load

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // save player position for next scene
            PlayerPrefs.SetFloat("playerX", position.x);
            PlayerPrefs.SetFloat("playerY", position.y);

            // load next scene
            SceneManager.LoadScene(sceneName);
        }
    }
}
