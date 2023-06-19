using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Michsky.LSS; // LSS namespace

public class StartSceneLoadTrigger : MonoBehaviour
{
    [SerializeField] private LoadingScreenManager lsmManager;

    // Update is called once per frame
    bool hasFired = false;

    void Update()
    {
        Debug.Log("Started");
        if (!hasFired && Time.timeSinceLevelLoad > 1)
        {
            lsmManager.LoadScene("Main Menu");
            hasFired = true;
        }
    }
}
