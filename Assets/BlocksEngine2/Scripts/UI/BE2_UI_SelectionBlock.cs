using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class BE2_UI_SelectionBlock : MonoBehaviour
{
    public GameObject prefabBlock;

    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            Transform prefChild = prefabBlock.transform.GetChild(i);

            for (int j = 0; j < child.childCount; j++)
            {
                Transform cc = child.GetChild(j);
                Transform prefcc = prefChild.GetChild(j);

                cc.GetComponent<RectTransform>().sizeDelta = prefcc.GetComponent<RectTransform>().sizeDelta;
            }
        }
    }
}
