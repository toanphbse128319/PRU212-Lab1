using TMPro;
using UnityEngine;

public class PointCalculator : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int _point;
    private int _timebasedPoint;
    private float _startTime;

    void Start()
    {
        _point = 0;
        _startTime = Time.fixedTime;
        UpdateScoreText();
    }

    void Update()
    {
        if (gameObject.activeSelf == false)
        {
            return;
        }

        _startTime += Time.deltaTime;
        if(_startTime >= 1)
        {
            _timebasedPoint += 1;
            _startTime = 0; // Reset the start time for the next calculation
        }
        UpdateScoreText(); 
    }

    public void AddPoint(int amount)
    {
        _point += amount;
        UpdateScoreText();
    }

    public void SetPoint(int number)
    {
        _point = number;
        UpdateScoreText();
    }

    public int GetPoint()
    {
        return _point + _timebasedPoint;
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + GetPoint().ToString();
        }
    }
}
