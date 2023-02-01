using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OverWorldSceneChanger : MonoBehaviour
{

    [SerializeField] private GameObject transitionBox;
    [SerializeField] private CinemachineRecomposer composer;
    public Vector2 position; // position to move player to in next scene
    public string sceneName; // name of next scene to load
    public static bool playerExited = false;

    private void Start() {
        transitionBox.gameObject.SetActive(true);

        LeanTween.scale(transitionBox, new Vector3(1, 1, 1), 0f);
        LeanTween.scaleY(transitionBox, 0, 1f).setEase(LeanTweenType.easeInOutExpo).setOnComplete(() => {
            transitionBox.gameObject.SetActive(false);
        });
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            transitionBox.gameObject.SetActive(true);
            // save player position for next scene
            PlayerPrefs.SetFloat("playerX", position.x);
            PlayerPrefs.SetFloat("playerY", position.y);

            LeanTween.scale(transitionBox, new Vector3(1, 0, 1), 0f);
            LeanTween.scaleY(transitionBox, 1, 1f).setEase(LeanTweenType.easeInOutExpo).setOnComplete(() => {
                SceneManager.LoadScene(sceneName);
            });
            playerExited = true;
        }
    }

    private void ZoomIn() {
        Debug.Log("Zooming in");
        // Set the starting and ending zoom values
        float startZoom = composer.m_ZoomScale;
        float endZoom = 0.7f;
        // Start the smooth zoom
        LeanTween.value(startZoom, endZoom, 0.6f).setOnUpdate((float val) => {
            // Set the camera's zoom value to the current animation value
            composer.m_ZoomScale = val;
        }).setEaseInOutExpo();
        SceneManager.LoadScene(sceneName);
    }
}
