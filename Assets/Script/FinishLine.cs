using UnityEngine;
using UnityEngine.SceneManagement; 

public class FinishLine : MonoBehaviour
{
    [SerializeField] private GameObject winPanel; 

    private bool hasFinished = false; 

    private void Start()
    {
        winPanel.SetActive(false); 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasFinished) 
        {
            hasFinished = true; 
            winPanel.SetActive(true); 
            Time.timeScale = 0; 
        }
    }

    
    public void NextLevel()
    {
        Time.timeScale = 1; 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu"); 
    }

    public void Retry()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }
    public void Credit()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Credit"); 
    }
}