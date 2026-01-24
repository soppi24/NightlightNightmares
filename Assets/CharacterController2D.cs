using UnityEngine;
using UnityEngine.UI;



public class CharacterController2D : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Sprite flashlightOnSprite; 
    public Sprite flashlightOffSprite; 
    public BoxCollider2D playerBodyCollider; 
    public BoxCollider2D flashlightBeamCollider;
    private Collider2D backgroundCollider;
    private Collider2D playerCollider;

    private SpriteRenderer spriteRenderer;
    private bool flashlightOn;
    private Vector2 movement;
    private Vector2 originalBeamOffset; 
    private Vector2 originalBodyOffset; 

    public Image batteryIcon; 
    public Sprite[] batterySprites;    
    public float maxBatteryTime = 100f; 
    private float currentBattery; 

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        backgroundCollider = GameObject.Find("Park Ground").GetComponent<Collider2D>();
        playerCollider = GetComponent<Collider2D>();

    
        originalBeamOffset = flashlightBeamCollider.offset;
        originalBodyOffset = playerBodyCollider.offset;

  
        UpdateColliders();


        if (batteryIcon == null)
        {
            GameObject batteryUIObject = GameObject.Find("BatteryIcon");
            if (batteryUIObject != null)
            {
                batteryIcon = batteryUIObject.GetComponent<Image>();
            }
            else
            {
                Debug.LogError("BatteryIcon GameObject not found, make sure in the Hierarchy.");
            }
        }

        currentBattery = maxBatteryTime; 
        UpdateBatteryIcon();
    }

    void Update()
    {
  
        // Core movement logic here, literally these two lines
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        if (Input.GetMouseButtonDown(0))
        {
            flashlightOn = !flashlightOn;
            UpdateCostume();
            UpdateColliders();
        }
        
        if (flashlightOn)
        {
            currentBattery -= Time.deltaTime; 
            currentBattery = Mathf.Clamp(currentBattery, 0, maxBatteryTime); 
            UpdateBatteryIcon();
        }
        
        
        if (movement.x > 0)
        {
            spriteRenderer.flipX = true; 
            FlipColliders(false); 
        }
        else if (movement.x < 0)
        {
            spriteRenderer.flipX = false; 
            FlipColliders(true);
        }
    }

    // This function too
    void FixedUpdate()
    {

        Vector2 newPosition = (Vector2)transform.position + movement * (moveSpeed * Time.fixedDeltaTime);

        newPosition = ClampToBounds(newPosition);

        transform.position = newPosition;
    }

    Vector2 ClampToBounds(Vector2 position)
    {
        Bounds bounds = backgroundCollider.bounds;
        float clampedX;
        float clampedY;
        if (playerCollider != null)
        {
            Bounds playerBounds = playerCollider.bounds;
            float halfWidth = playerBounds.extents.x;
            float halfHeight = playerBounds.extents.y;
            
            clampedX = Mathf.Clamp(position.x, bounds.min.x + halfWidth, bounds.max.x - halfWidth);
            clampedY = Mathf.Clamp(position.y, bounds.min.y + halfHeight, bounds.max.y - halfHeight);
        }
        else
        {
            clampedX = Mathf.Clamp(position.x, bounds.min.x, bounds.max.x);
            clampedY = Mathf.Clamp(position.y, bounds.min.y, bounds.max.y);
        }
    
        return new Vector2(clampedX, clampedY);
    }

    void UpdateCostume()
    {
        spriteRenderer.sprite = flashlightOn ? flashlightOnSprite : flashlightOffSprite;
    }

    void UpdateColliders()
    {

        if (flashlightOn)
        {
            flashlightBeamCollider.enabled = true;
            playerBodyCollider.enabled = true;
        }
        else
        {
            flashlightBeamCollider.enabled = false;
            playerBodyCollider.enabled = true;
        }
    }

    void FlipColliders(bool facingRight)
    {
       
        flashlightBeamCollider.offset = new Vector2(
            facingRight ? originalBeamOffset.x : -originalBeamOffset.x,
            originalBeamOffset.y
        );

        
        playerBodyCollider.offset = new Vector2(
            facingRight ? originalBodyOffset.x : -originalBodyOffset.x,
            originalBodyOffset.y
        );
    }
    void UpdateBatteryIcon()
    {
       
        float batteryPercentage = (currentBattery / maxBatteryTime) * 100;

        
        if (batteryPercentage > 75)
        {
            batteryIcon.sprite = batterySprites[0]; // Full battery
        }
        else if (batteryPercentage > 50)
        {
            batteryIcon.sprite = batterySprites[1]; // 75-51%
        }
        else if (batteryPercentage > 25)
        {
            batteryIcon.sprite = batterySprites[2]; // 50-26%
        }
        else if (batteryPercentage > 0)
        {
            batteryIcon.sprite = batterySprites[3]; // 25-1%
        }
        // Need Last Else statement for empty battery lol
    }

}
