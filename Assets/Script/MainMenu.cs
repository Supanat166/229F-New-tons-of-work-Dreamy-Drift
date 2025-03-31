using UnityEngine;
using UnityEngine.SceneManagement; 
using UnityEngine.UI; 

public class MainMenu : MonoBehaviour
{
    
    [SerializeField] private Button playButton;
    [SerializeField] private Button creditButton;
    [SerializeField] private Button quitButton; 

    private void Start()
    {
        
        if (playButton != null)
        {
            playButton.onClick.AddListener(PlayGame); 
        }
        if (creditButton != null)
        {
            creditButton.onClick.AddListener(ShowCredits); 
        }
        if (quitButton != null)
        {
            quitButton.onClick.AddListener(QuitGame); 
        }
    }

    
    private void PlayGame()
    {
        
        SceneManager.LoadScene("Level1"); 
    }

    
    private void ShowCredits()
    {
        
        SceneManager.LoadScene("Credit"); 
    }

    
    private void QuitGame()
    {
        
        Debug.Log("Exiting game...");

        
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit(); // ออกจากเกมในแพลตฟอร์มจริง
#endif
    }
}