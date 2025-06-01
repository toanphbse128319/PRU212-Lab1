using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collision : MonoBehaviour
{
    public GameObject[] DisappearOnHit;
    public GameObject[] AppearOnHit;
    public PointCalculator _pointCal;
    public Movement Movement;
    public Lose Lose;
    public Fuelbar _fuelbar;
    private bool hit;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    void OnTriggerEnter2D(Collider2D collision){
        if(collision.name == "Fuel"){
            _fuelbar.AddFuel(30f);
            _pointCal.AddPoint(5);
            return;
        }
        if(hit == true)
            return;
        for (int i = 0; i < DisappearOnHit.Length; ++i){
            DisappearOnHit[i].SetActive(false);
        }
        for(int i = 0; i < AppearOnHit.Length; ++i){
            AppearOnHit[i].SetActive(true);
        }
        Lose.SetLose();
        PlayerPrefs.SetInt("Score", _pointCal.GetPoint());
        hit = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (hit == false)
            return;
    }
}
