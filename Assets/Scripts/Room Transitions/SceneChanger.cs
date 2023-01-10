using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string sceneName;
    [SerializeField] private RectTransform transitionSphere;
    [SerializeField] private CinemachineRecomposer composer;

    private void Start() {
        transitionSphere.gameObject.SetActive(true);

        LeanTween.scale(transitionSphere, new Vector3(1, 1, 1), 0f);
        LeanTween.scale(transitionSphere, new Vector3(0, 0, 0), 0.6f).setEase(LeanTweenType.easeOutQuad).setOnComplete(() => {
            transitionSphere.gameObject.SetActive(false);
        });
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            transitionSphere.gameObject.SetActive(true);
            LeanTween.scale(transitionSphere, new Vector3(0, 0, 0), 0f);
            LeanTween.scale(transitionSphere, new Vector3(1, 1, 1), 0.6f).setEase(LeanTweenType.easeInQuad).setOnComplete(() => {
                ZoomIn();
            });
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
