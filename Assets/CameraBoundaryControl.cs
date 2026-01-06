using UnityEngine;

public class CameraBoundaryControl : MonoBehaviour
{
    public Transform player;           
    public Transform background;        
    private Vector2 minBounds;          
    private Vector2 maxBounds;          

    private float cameraHalfWidth;      
    private float cameraHalfHeight;     

    void Start()
    {
        SpriteRenderer backgroundRenderer = background.GetComponent<SpriteRenderer>();
        if (backgroundRenderer == null)
        {
            Debug.LogError("Background does not have a SpriteRenderer!");
            return;
        }

        float halfBackgroundWidth = (backgroundRenderer.bounds.size.x * background.localScale.x) / 2f;
        float halfBackgroundHeight = (backgroundRenderer.bounds.size.y * background.localScale.y) / 2f;

        minBounds = new Vector2(background.position.x - halfBackgroundWidth, background.position.y - halfBackgroundHeight);
        maxBounds = new Vector2(background.position.x + halfBackgroundWidth, background.position.y + halfBackgroundHeight);

        Camera mainCamera = Camera.main;
        cameraHalfHeight = mainCamera.orthographicSize;
        cameraHalfWidth = mainCamera.orthographicSize * mainCamera.aspect;

        Debug.Log($"Camera Bounds: Min {minBounds}, Max {maxBounds}");
    }

    void LateUpdate()
    {
        Vector3 playerPosition = player.position;

        float clampedX = Mathf.Clamp(playerPosition.x, minBounds.x + cameraHalfWidth, maxBounds.x - cameraHalfWidth);
        float clampedY = Mathf.Clamp(playerPosition.y, minBounds.y + cameraHalfHeight, maxBounds.y - cameraHalfHeight);

        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }
}
