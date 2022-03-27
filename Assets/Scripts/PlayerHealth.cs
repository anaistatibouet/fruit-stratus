using UnityEngine;
using System.Collections;


public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth = 0;
    public float invicibilityTimeAfterHit = 1f;
    public float invicibilityFlashDelay = 0.2f;
    public SpriteRenderer graphics;
    public bool isInvicible = false;
    public HealthBar healthbar;

    public static PlayerHealth instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de PlayerHealth dans la sc�ne");
            return;
        }

        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int damage)
    {
        if (!isInvicible)
        {
            currentHealth -= damage;
            healthbar.SetHealth(currentHealth);
            if(currentHealth > 0)
            {
                isInvicible = true;
                StartCoroutine(InvicibilityFlash());
                StartCoroutine(HandleInvicibilityFlashDelay());
            }
            else
            {
                this.Die();
            }
        }
    }
    public void RestoreHealth(int health)
    {
        if(currentHealth + health > maxHealth) {
            currentHealth = maxHealth;
        } 
        else 
        {
            currentHealth += health;
        }
        healthbar.SetHealth(currentHealth);
    }

    public void Die()
    {
        Debug.Log("Le joueur a perdu");
        GameOverManager.instance.OnPlayerDeath();
    }

    public void Respawn() {
        currentHealth = maxHealth;
        healthbar.SetHealth(currentHealth);
        Inventory.instance.ResetFruitCount();
    }

    public IEnumerator InvicibilityFlash() {
        while(isInvicible) {
            graphics.color = new Color(1f, 1f, 1f, 0f);
            yield return new WaitForSeconds(invicibilityFlashDelay);
            graphics.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(invicibilityFlashDelay);
        }
    }
    
    public IEnumerator HandleInvicibilityFlashDelay()
    {
        yield return new WaitForSeconds(invicibilityTimeAfterHit);
        isInvicible = false;
    }
}
