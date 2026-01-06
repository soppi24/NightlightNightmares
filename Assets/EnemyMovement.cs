using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform rv;       
    public float moveSpeed = 1f; 

    void Update()
    {
        if (rv == null) return;

    
        Vector3 direction = (rv.position - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;
    }
}
