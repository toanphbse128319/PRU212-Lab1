using UnityEngine;

public class ButtonBehavior : MonoBehaviour
{
    public Pause Pause; 
    public GameObject instructionsPanel;
    public GameObject mainMenuButtons;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnContinue()
    {
        Debug.Log("Trying to start");
        Pause.OnResume();
    }

    public void ShowIntroduction()
    {
        instructionsPanel.SetActive(true);
        mainMenuButtons.SetActive(false); // Ẩn menu chính
    }

    public void HideInstructions()
    {
        instructionsPanel.SetActive(false);
        mainMenuButtons.SetActive(true); // Hiện lại menu chính
    }

    public void OnQuit()
    {
        Debug.Log("Quit Game");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Thoát khỏi chế độ Play trong Editor
#else
        Application.Quit(); // Thoát thật khi build
#endif
    }

}
