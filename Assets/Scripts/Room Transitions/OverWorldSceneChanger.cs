using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OverWorldSceneChanger : MonoBehaviour
{

    [SerializeField] private RectTransform transitionSphere;
    public Vector2 position; // position to move player to in next scene
    public string sceneName; // name of next scene to load

    private void Start() {
        transitionSphere.gameObject.SetActive(true);

        LeanTween.scale(transitionSphere, new Vector3(1, 1, 1), 0f);
        LeanTween.scale(transitionSphere, new Vector3(0, 0, 0), 0.6f).setEase(LeanTweenType.easeOutQuad).setOnComplete(() => {
            transitionSphere.gameObject.SetActive(false);
        });
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            transitionSphere.gameObject.SetActive(true);
            // save player position for next scene
            PlayerPrefs.SetFloat("playerX", position.x);
            PlayerPrefs.SetFloat("playerY", position.y);

            LeanTween.scale(transitionSphere, new Vector3(0, 0, 0), 0f);
            LeanTween.scale(transitionSphere, new Vector3(1, 1, 1), 0.6f).setEase(LeanTweenType.easeInQuad).setOnComplete(() => {
                SceneManager.LoadScene(sceneName);
            });
        }
    }
}
