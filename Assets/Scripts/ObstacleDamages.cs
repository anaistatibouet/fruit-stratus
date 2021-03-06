using UnityEngine;

public class ObstacleDamages : MonoBehaviour
{
    public int damageOnCollision = 10;
    public bool ignoreInvincible = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.transform.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(damageOnCollision, ignoreInvincible);
        }
    }
}
