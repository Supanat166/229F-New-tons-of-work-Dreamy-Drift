using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private Transform shootPoint; 
    [SerializeField] private GameObject shootPointPrefab; 
    [SerializeField] private AudioClip shootSound;  
    private AudioSource audioSource;  

    void Start()
    {
        
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();  
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            Shooting();
        }
    }

    void Shooting()
    {
        RaycastHit hit;

        Debug.DrawRay(shootPoint.position, shootPoint.forward * 30f, Color.red);

        if (Physics.Raycast(shootPoint.position, shootPoint.forward, out hit, 30f))
        {
            Debug.DrawRay(shootPoint.position, shootPoint.forward * hit.distance, Color.green);
            
            
            GameObject fireObj = Instantiate(shootPointPrefab, shootPoint.position, Quaternion.identity);
            Destroy(fireObj, 1);

            
            if (shootSound != null)
            {
                audioSource.PlayOneShot(shootSound);
            }
            
            ICanDamage damageable = hit.collider.GetComponent<ICanDamage>();
            if (damageable != null)
            {
                damageable.TakeDamage(10);  
            }
        }
    }
}