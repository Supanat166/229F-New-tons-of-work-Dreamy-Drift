using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsManager : MonoBehaviour
{
    
    public float timeBeforeReturnToMenu = 5f;

    
    void Start()
    {
        
        Invoke("GoToMenu", timeBeforeReturnToMenu);
    }

    
    void GoToMenu()
    {
        
        SceneManager.LoadScene("MainMenu");
    }
}

