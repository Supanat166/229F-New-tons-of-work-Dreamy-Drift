using UnityEngine;

public class MovementCharacter : MonoBehaviour
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

    private void Update()
    {
        
        if (health <= 0) return;

        float move = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector3(move * moveSpeed, rb.linearVelocity.y, rb.linearVelocity.z);

        
        LimitRotation();
    }

    public void ReduceSpeed(float amount)
    {
        moveSpeed = Mathf.Max(1f, moveSpeed - amount); 
        Debug.Log("Speed Reduced: " + moveSpeed);
    }

    
    //public void TakeDamage(float amount)
    //{
    //   health -= amount;
    //   health = Mathf.Clamp(health, 0, maxHealth); 

        
    //  if (healthBar != null)
    //    {
     //       healthBar.UpdateHealthBar(health, maxHealth); 
    //    }

      //  if (health <= 0)
    //    {
     //       Die(); 
    //    }
    //}
   

   
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            rb.angularVelocity = Vector3.zero;
            LimitRotation(); 
        }
    }

    
    private void LimitRotation()
    {
        Vector3 currentRotation = transform.eulerAngles;

        
        float clampedX = Mathf.Clamp((currentRotation.x > 180) ? currentRotation.x - 360 : currentRotation.x, -15f, 15f);

        
        float lockedY = 0f;
        float lockedZ = 0f;

        
        transform.rotation = Quaternion.Euler(clampedX, lockedY, lockedZ);
    }
}
