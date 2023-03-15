using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomLoader : MonoBehaviour
{
    // get the animator serializable
    [SerializeField] private Animator loader;
    // Start is called before the first frame update
    void Start()
    {
        // i have 5 different loaders named load1 load2 load3 load4 load5 load6 load7
        // I want to pick a random one and play it everytime the prefab is loaded
        // so i get a random number between 1 and 7
        int random = Random.Range(1, 7);

        List<string> anims = new List<string>();
        anims.Add("load1");
        anims.Add("load2");
        anims.Add("load3");
        anims.Add("load4");
        anims.Add("load5");
        anims.Add("load6");
        anims.Add("load7");

        loader.Play(anims[random]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
