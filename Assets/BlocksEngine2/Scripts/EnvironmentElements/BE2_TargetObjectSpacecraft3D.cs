using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BE2_TargetObjectSpacecraft3D : BE2_TargetObject
{
    GameObject _bullet;

    public new Transform Transform => transform;

    void Awake()
    {
        // v2.6 - changed way to find "bullet" child of Target Object
        //_bullet = transform.GetChild(transform.childCount-1).gameObject;
        foreach (Transform child in transform)
        {
            if (child.name == "Bullet")
                _bullet = child.gameObject;
        }

    }

    //void Start()
    //{
    //
    //}

    //void Update()
    //{
    //
    //}

    public void Shoot()
    {
        GameObject newBullet = Instantiate(_bullet, _bullet.transform.position, Quaternion.identity);
        newBullet.SetActive(true);
        newBullet.GetComponent<Rigidbody>().AddForce(transform.forward * 1000);
        StartCoroutine(C_DestroyTime(newBullet));
    }
    IEnumerator C_DestroyTime(GameObject go)
    {
        yield return new WaitForSeconds(1f);
        Destroy(go);
    }
}
