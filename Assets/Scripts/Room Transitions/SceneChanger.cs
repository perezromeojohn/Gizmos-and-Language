using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string sceneName;
    [SerializeField] private RectTransform transitionSphere;

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
                SceneManager.LoadScene(sceneName);
            });
        }
    }
}
