using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuCamera : MonoBehaviour
{
    public float speed = 5f;
    public GameObject boundsGO;
    private Vector3 direction;
    private Vector3 lastDirection;
    private Bounds bounds;
    
    void Start()
    {
        bounds = boundsGO.GetComponent<Collider>().bounds;
        direction = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f);
        lastDirection = direction;
    }

    void FixedUpdate()
    {
        Vector3 newPos = transform.position + direction * speed * Time.fixedDeltaTime;
        if (!bounds.Contains(newPos))
        {
            if (newPos.x < bounds.min.x || newPos.x > bounds.max.x) 
            {
                direction.x = -direction.x;
                direction.y = Random.Range(-1f, 1f);
            }
            if (newPos.y < bounds.min.y || newPos.y > bounds.max.y) 
            {
                direction.y = -direction.y;
                direction.x = Random.Range(-1f, 1f);
            }
        }
        lastDirection = direction;
        transform.position = Vector3.Lerp(transform.position, newPos, Time.deltaTime);
    }
}
