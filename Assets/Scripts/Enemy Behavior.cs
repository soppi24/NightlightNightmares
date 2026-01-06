using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public float moveSpeed = 0.5f;     
    public float bobbingSpeed = 1f;  
    public float bobbingAmount = 0.5f; 
    public Sprite dyingSprite;       
    public Transform prize;          

    private Vector2 originalPosition;
    private bool isDying = false;


    public BoxCollider2D flashlightBeamCollider; 
    public BoxCollider2D playerBodyCollider;    

    void Start()
    {
        originalPosition = transform.position;

        if (prize == null)
        {
            Debug.LogError("EnemyBehavior: No prize object assigned. Please assign one in the Inspector or via script.");
        }
        
        BoxCollider2D[] colliders = GameObject.Find("Rosa").GetComponents<BoxCollider2D>();
        if (colliders.Length == 2)
        {
            playerBodyCollider = colliders[1];
            flashlightBeamCollider = colliders[0];
        }
        else
        {
            Debug.LogError("EnemyBehavior: Could not find exactly two BoxCollider2D components on the Player GameObject.");
        }
    }

    void Update()
    {
        if (isDying || prize == null)
            return;

        float bobbingOffset = Mathf.Sin(Time.time * bobbingSpeed) * bobbingAmount;

        Vector2 directionToPrize = (Vector2)prize.position - (Vector2)transform.position;

        Vector2 targetPosition = new Vector2(prize.position.x, prize.position.y + bobbingOffset);

        transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other == flashlightBeamCollider)
        {
            HandleDeath("Enemy destroyed by flashlight beam!");
        }

        else if (other == playerBodyCollider)
        {
            //HandleDeath("Enemy collided with the player!");
            // Don't do this lol
        }
    }

    private void HandleDeath(string logMessage)
    {
        if (isDying) return;

        isDying = true;
        Debug.Log(logMessage);
        GetComponent<SpriteRenderer>().sprite = dyingSprite;

        Destroy(gameObject, 0.5f);
    }
}
