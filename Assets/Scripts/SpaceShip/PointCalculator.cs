using UnityEngine;

public class PointCalculator : MonoBehaviour
{
    public int _point;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.activeSelf == false){
            return;
        }
        _point = (int)Mathf.Floor(Time.fixedTime);
    }

    public void AddPoint(int amount){
        _point += amount;
    }

    public void SetPoint(int number){
        _point = number;
    }

    public int GetPoint(){
        return _point;
    }
}
