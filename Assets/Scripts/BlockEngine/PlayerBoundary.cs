using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoundary : MonoBehaviour
{
    private BoxCollider2D boundaryCollider;

    // Reference to the player's collider
    [SerializeField] private BoxCollider2D playerCollider;

    private void Start()
    {
        boundaryCollider = GetComponent<BoxCollider2D>();
    }

    private void LateUpdate()
    {
        // Restrict the player's position to the boundary box
        Vector3 playerPos = playerCollider.transform.position;
        Vector3 boundaryPos = boundaryCollider.transform.position;
        Vector3 boundarySize = boundaryCollider.bounds.size;
        Vector3 boundaryMin = boundaryPos - boundarySize / 2;
        Vector3 boundaryMax = boundaryPos + boundarySize / 2;
        playerPos.x = Mathf.Clamp(playerPos.x, boundaryMin.x + playerCollider.size.x / 2, boundaryMax.x - playerCollider.size.x / 2);
        playerPos.y = Mathf.Clamp(playerPos.y, boundaryMin.y + playerCollider.size.y / 2, boundaryMax.y - playerCollider.size.y / 2);
        playerCollider.transform.position = playerPos;
    }
}
