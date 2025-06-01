using UnityEngine;
using UnityEngine.UI;

public class Fuelbar : MonoBehaviour
{
    public Image FuelbarFill;
    public Lose Lose;
    public Movement Movement;
    public GameObject[] DisableOnEmpty;
    public float MaxFuel = 100f;
    public float CurrentFuel;
    public float DrainRate = 5f;
    private bool _disabled = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CurrentFuel = MaxFuel;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(CurrentFuel);
        if (CurrentFuel <= 0 && _disabled == false)
        {
            foreach(GameObject data in DisableOnEmpty)
            {
                data.SetActive(false);
            }
            _disabled = true;
            Lose.SetLose();
            return;
        }
        CurrentFuel -= (DrainRate * Time.deltaTime);
        CurrentFuel = Mathf.Clamp(CurrentFuel, 0, MaxFuel);
        FuelbarFill.fillAmount = CurrentFuel / MaxFuel;
    }

    public void Reset()
    {
        if (_disabled == false) return;
        _disabled = false;
        foreach (GameObject data in DisableOnEmpty)
        {
            data.SetActive(true);
        }
        Lose.Reset();
    }
    public void SetFuel(float amount){
        if (amount > 0) Reset();
        CurrentFuel = Mathf.Clamp(amount, 0, MaxFuel); 
    }

    public void AddFuel(float amount){
        if (CurrentFuel <= 0 && CurrentFuel + amount > 0) Reset();
        SetFuel(CurrentFuel + amount);
    }

    public void UseFuel(float amount){
        SetFuel(CurrentFuel - amount);
    }

    public float GetFuel()
    {
        return CurrentFuel;
    }
    
    public void SetDrain(float drain)
    {
        DrainRate = drain;
    }
    public float GetDrain()
    {
        return DrainRate;
    }
}
