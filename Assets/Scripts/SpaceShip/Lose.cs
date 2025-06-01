using UnityEngine;

public class Lose : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    float loseTime;
    private bool _isLose = false;
    void Start()
    {
    }
     
    public void SetLose()
    {
        Debug.Log("Game over is setting in");
        _isLose = true;
        loseTime = Time.fixedTime;
    }

    public void Reset()
    {
        _isLose = false;
        loseTime = Time.fixedTime;

    }

    // Update is called once per frame
    void Update()
    {
        if(_isLose == false)
            return;
        if(Time.fixedTime - loseTime > 3f)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
        }
    }
}
