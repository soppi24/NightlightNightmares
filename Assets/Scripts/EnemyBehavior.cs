using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public float moveSpeed = 0.5f;     
    public Sprite dyingSprite;       
    public Transform prize;          
    private bool isDying;


    BoxCollider2D flashlightBeamCollider; 
    BoxCollider2D playerBodyCollider;    

    void Start()
    {
        if (prize == null)
        {
            Debug.LogError("EnemyBehavior: No prize (Or RV) object assigned");
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
        
        Vector2 targetPosition = new Vector2(prize.position.x, prize.position.y);

        transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }


    void OnTriggerEnter2D(Collider2D colliderName)
    {
        if (colliderName == flashlightBeamCollider)
        {
            HandleDeath("Enemy destroyed by flashlight beam!");
        }

        else if (colliderName == playerBodyCollider)
        {
            //HandleDeath("Enemy NOT destroyed by flashlight beam! Rosa RUN");
            Debug.Log("Enemy NOT destroyed by flashlight beam! Rosa RUN");
            // Don't do this lol, a future feature or challenge is making the character die after being touched,
            // Perhaps in the same method or another
        }
    }

    private void HandleDeath(string logMessage)
    {
        if (isDying) return;

        // Set the dying to true, change the image to pompei baby, destroy object after 0.5 sec, increase kill count 
        isDying = true;
        Debug.Log(logMessage);
        GetComponent<SpriteRenderer>().sprite = dyingSprite;

        Destroy(gameObject, 0.5f);
        CountingScript.instance.CountUp();
        
    }
}
