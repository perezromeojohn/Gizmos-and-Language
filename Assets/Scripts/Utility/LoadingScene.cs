using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class LoadingScene : MonoBehaviour
{
    public static LoadingScene instance;
    [SerializeField] private string sceneName;
    [SerializeField] private GameObject transitionBox;
    [SerializeField] private GameObject loadingGraphic;

    void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    void Start() {
        LoadScene();
    }

    public async void LoadScene() {
        var scene = SceneManager.LoadSceneAsync(sceneName);
        scene.allowSceneActivation = false;

        transitionBox.SetActive(true);
        loadingGraphic.SetActive(true);

        do {
            await Task.Delay(100);
            Debug.Log("Loading progress: " + scene.progress);
        } while (scene.progress < 0.9f);
        scene.allowSceneActivation = true;

        // LeanTween.scale(transitionBox, new Vector3(0, 0, 0), 0.6f).setEase(LeanTweenType.easeInOutExpo).setOnComplete(() => {
        //     transitionBox.gameObject.SetActive(false);
        // });

        LeanTween.scale(loadingGraphic, new Vector3(0, 0, 0), 0.2f).setEase(LeanTweenType.easeInOutExpo).setOnComplete(() => {
            loadingGraphic.gameObject.SetActive(false);
        });

        // LeanTween scale only x axis
        LeanTween.scaleY(transitionBox, 0, 1f).setEase(LeanTweenType.easeInOutExpo).setOnComplete(() => {
            transitionBox.gameObject.SetActive(false);
        });
        
        
        Debug.Log("Scene loaded");
    }
    
}
