using System.Collections;

using UnityEngine;

public class EnemyFlashlightInteraction : MonoBehaviour
{
    public Sprite dyingSprite;   
    public float deathDelay = 0.5f; 
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Flashlight"))
        {
            StartCoroutine(Die());
        }
    }

    private IEnumerator Die()
    {

        if (dyingSprite != null)
        {
            spriteRenderer.sprite = dyingSprite;
        }

        yield return new WaitForSeconds(deathDelay);


        Destroy(gameObject);
    }
}
