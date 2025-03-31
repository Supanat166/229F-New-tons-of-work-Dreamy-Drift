using UnityEngine;
using UnityEngine.UI; 

public class HealthChange: MonoBehaviour
{
    [SerializeField] private Slider healthSlider;
    [SerializeField] private Image fillImage;  
    [SerializeField] private Color fullHealthColor = Color.green;  
    [SerializeField] private Color lowHealthColor = Color.red;  

    private void Start()
    {
        if (healthSlider != null)
        {
            
            healthSlider.value = healthSlider.maxValue; 
        }
    }

    public void UpdateHealthBar(float currentHealth, float maxHealth)
    {
        if (healthSlider != null)
        {
            
            healthSlider.value = currentHealth;

            
            float healthPercentage = currentHealth / maxHealth;

            
            fillImage.color = Color.Lerp(lowHealthColor, fullHealthColor, healthPercentage);
        }
    }
}