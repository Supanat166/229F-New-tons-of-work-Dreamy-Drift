using UnityEngine;

public class Car : MonoBehaviour
{
    public float moveSpeed = 7f;
    public float health = 15f;
    public float maxHealth = 15f;
    private Rigidbody rb;

    private HealthBar healthBar;

    [SerializeField] private GameObject gameOverPanel;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        healthBar = FindObjectOfType<HealthBar>();
        if (healthBar != null)
        {
            healthBar.UpdateHealthBar(health, maxHealth);
        }

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }
    }
    
    public void ReduceSpeed(float amount)
    {
        moveSpeed = Mathf.Max(1f, moveSpeed - amount); 
        Debug.Log("Speed Reduced: " + moveSpeed);
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        health = Mathf.Clamp(health, 0, maxHealth);

        if (healthBar != null)
        {
            healthBar.UpdateHealthBar(health, maxHealth);
        }

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Character is dead!");
        rb.linearVelocity = Vector3.zero;

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }

        Time.timeScale = 0;
    }
}