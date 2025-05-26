using UnityEngine;
using UnityEngine.UI;

public class Fuelbar : MonoBehaviour
{
    public Image FuelbarFill;
    public float MaxFuel = 100f;
    public float CurrentFuel;
    public float DrainRate = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CurrentFuel = MaxFuel;
    }

    // Update is called once per frame
    void Update()
    {
        if(CurrentFuel <= 0)
            return;
        CurrentFuel -= (DrainRate * Time.deltaTime);
        CurrentFuel = Mathf.Clamp(CurrentFuel, 0, MaxFuel);
        FuelbarFill.fillAmount = CurrentFuel / MaxFuel;
    }

    public void SetFuel(float amount){
        CurrentFuel = Mathf.Clamp(amount, 0, MaxFuel); 
    }

    public void AddFuel(float amount){
        SetFuel(CurrentFuel + amount);
    }

    public void UseFuel(float amount){
        SetFuel(CurrentFuel - amount);
    }
}
