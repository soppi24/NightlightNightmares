using UnityEngine;

public class InsideTriggerDetector : MonoBehaviour
{
    private bool isInside = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        {
            isInside = true;
            Debug.Log("Player is inside the trigger.");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Replace "Player" with the relevant tag
        {
            isInside = false;
            Debug.Log("Player exited the trigger.");
        }
    }

    void Update()
    {
        if (isInside)
        {
            // Logic for when the player is inside
        }
    }
}
