using UnityEngine;

public class Pause : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject[] ObjectsToPause;
    public GameObject[] ObjectsToAppearWhenPause;
    public bool IsPaused = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void onPause()
    {
        IsPaused = true;
        foreach (GameObject obj in ObjectsToPause)
        {
            obj.SetActive(false);
        }
        foreach (GameObject obj in ObjectsToAppearWhenPause)
        {
            obj.SetActive(true);
        }
    }

    public void OnResume()
    {
        IsPaused = false;
        foreach (GameObject obj in ObjectsToPause)
        {
            obj.SetActive(true);
        }
        foreach (GameObject obj in ObjectsToAppearWhenPause)
        {
            obj.SetActive(false);
        }
    }
}
