using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private float maxHealth = 15f;
    private float currentHealth;
    [SerializeField] private Image healthBarFill;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private Gradient colorGradient;

    void Start()
    {
        currentHealth = maxHealth;
        healthText.text = "Health: " + currentHealth;
    }

    
    public void UpdateHealthBar(float currentHealth, float maxHealth)
    {
        this.currentHealth = currentHealth;
        this.maxHealth = maxHealth;

        
        healthText.text = "Health: " + currentHealth;

        
        float targetFillAmount = currentHealth / maxHealth;
        healthBarFill.fillAmount = targetFillAmount;

        
        healthBarFill.color = colorGradient.Evaluate(targetFillAmount);
    }

    
    public void UpdateHealth(float amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
        healthText.text = "Health: " + currentHealth;
        UpdateHealthBar(currentHealth, maxHealth);
    }
}

