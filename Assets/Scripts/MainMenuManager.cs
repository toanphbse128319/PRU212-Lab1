using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MainMenuManager : MonoBehaviour
{
    public GameObject instructionsPanel;
    public GameObject mainMenuButtons;

    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void ShowInstructions()
    {
        instructionsPanel.SetActive(true);
        mainMenuButtons.SetActive(false); // Ẩn menu chính
    }

    public void HideInstructions()
    {
        instructionsPanel.SetActive(false);
        mainMenuButtons.SetActive(true); // Hiện lại menu chính
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");

#if UNITY_EDITOR
        EditorApplication.isPlaying = false; // Thoát khỏi chế độ Play trong Editor
#else
        Application.Quit(); // Thoát thật khi build
#endif
    }
}
