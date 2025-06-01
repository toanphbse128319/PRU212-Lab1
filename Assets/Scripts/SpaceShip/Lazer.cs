using UnityEngine;
using VolumetricLines;

public class Lazer : MonoBehaviour
{
    public GameObject LazerLine;
    public GameObject Sound;
    public Fuelbar Fuelbar;
    public VolumetricLineBehavior Line;
    public float FuelDarnMultiplier = 2.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        LazerLine.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 start = Line.StartPos;
        if(Input.GetKeyDown(KeyCode.Space)){
            if(LazerLine.activeSelf == false){
                Fuelbar.SetDrain(Fuelbar.GetDrain() * FuelDarnMultiplier);
                start = new Vector3(start.x, 0, start.z);
                Line.StartPos = start;
                LazerLine.SetActive(true);
                Sound.SetActive(true);
            }
        } else if(Input.GetKeyUp(KeyCode.Space)) {
            if(LazerLine.activeSelf == true){
                Fuelbar.SetDrain(Fuelbar.GetDrain() / FuelDarnMultiplier);
                start = new Vector3(start.x, 0, start.z);
                Line.StartPos = start;
                LazerLine.SetActive(false);
                Sound.SetActive(false);
            }
        }
    }

}
