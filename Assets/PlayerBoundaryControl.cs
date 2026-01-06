using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoundaryControl : MonoBehaviour
{
    public float moveSpeed = 5f;           
    public Transform background;          
    private Vector2 minBounds;            
    private Vector2 maxBounds;            

    private Vector2 movement;

    void Start()
    {
        SpriteRenderer backgroundRenderer = background.GetComponent<SpriteRenderer>();
        float halfWidth = (backgroundRenderer.bounds.size.x * background.localScale.x) / 2f;
        float halfHeight = (backgroundRenderer.bounds.size.y * background.localScale.y) / 2f;

        minBounds = new Vector2(background.position.x - halfWidth, background.position.y - halfHeight);
        maxBounds = new Vector2(background.position.x + halfWidth, background.position.y + halfHeight);

        Debug.Log($"Min Bounds: {minBounds}, Max Bounds: {maxBounds}");
    }


    void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
        Debug.Log($"Movement Input: {movement}");
    }

    void FixedUpdate()
    {
        Vector3 newPosition = transform.position + (Vector3)(movement * moveSpeed * Time.fixedDeltaTime);
        newPosition.x = Mathf.Clamp(newPosition.x, minBounds.x, maxBounds.x);
        newPosition.y = Mathf.Clamp(newPosition.y, minBounds.y, maxBounds.y);

        Debug.Log($"New Position: {newPosition}");
        transform.position = newPosition;
    }

}
