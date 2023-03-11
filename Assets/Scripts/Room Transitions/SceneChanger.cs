using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string sceneName;
    [SerializeField] private GameObject transitionBox;
    [SerializeField] private CinemachineRecomposer composer;

    // get player
    public static bool playerEntered = false;

    private void Start() {
        transitionBox.gameObject.SetActive(true);

        // LeanTween.scale(transitionBox, new Vector3(1, 1, 1), 0f);
        // LeanTween.scaleY(transitionBox, 0, 1f).setEase(LeanTweenType.easeInOutExpo).setOnComplete(() => {
        //     transitionBox.gameObject.SetActive(false);
        // });
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Debug.Log("Player entered trigger");
            // transitionBox.gameObject.SetActive(true);
            // LeanTween.scale(transitionBox, new Vector3(1, 0, 1), 0f);
            // LeanTween.scaleY(transitionBox, 1, 1f).setEase(LeanTweenType.easeInOutExpo).setOnComplete(() => {
            //     SceneManager.LoadScene(sceneName);
            // });
            // playerEntered = true;
        }
    }

    private void ZoomIn() {
        // Debug.Log("Zooming in");
        // // Set the starting and ending zoom values
        // float startZoom = composer.m_ZoomScale;
        // float endZoom = 0.7f;
        // // Start the smooth zoom
        // LeanTween.value(startZoom, endZoom, 0.6f).setOnUpdate((float val) => {
        //     // Set the camera's zoom value to the current animation value
        //     composer.m_ZoomScale = val;
        // }).setEaseInOutExpo();
        // SceneManager.LoadScene(sceneName);
    }
}
