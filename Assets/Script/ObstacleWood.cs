using UnityEngine;

public class ObstacleWood : MonoBehaviour, ICanDamage
{
    [SerializeField] private float health = 20f;
    [SerializeField] private GameObject hitEffectPrefab;
    [SerializeField] private float speedReduction = 1f;
    [SerializeField] private float damageAmount = 5f; 
    [SerializeField] private AudioClip hitSound;  
    [SerializeField] private AudioClip destroySound;  
    private AudioSource audioSource;  

    void Start()
    {
        
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();  
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        
        if (hitSound != null)
        {
            audioSource.PlayOneShot(hitSound);
        }

        if (hitEffectPrefab != null)
        {
            GameObject woodObj = Instantiate(hitEffectPrefab, transform.position, Quaternion.identity);
            Destroy(woodObj, 1);
        }

        if (health <= 0)
        {
            
            if (destroySound != null)
            {
                audioSource.PlayOneShot(destroySound);
            }

            Destroy(gameObject); 
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Car player = collision.gameObject.GetComponent<Car>();
            if (player != null)
            {
                player.ReduceSpeed(speedReduction); 
                player.TakeDamage(damageAmount); 
            }

            Destroy(gameObject); 
        }
    }
}