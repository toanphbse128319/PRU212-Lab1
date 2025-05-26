using UnityEngine;

public class Collision : MonoBehaviour
{
    public GameObject[] DisappearOnHit;
    public GameObject[] AppearOnHit;
    private PointCalculator _pointCal;
    private Fuelbar _fuelbar;
    private bool hit;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _fuelbar = GetComponent<Fuelbar>();
        _pointCal = GetComponent<PointCalculator>();
    }

    void OnTriggerEnter2D(Collider2D collision){
        if(collision.name == "Fuel"){
            _fuelbar.AddFuel(30f);
            _pointCal.AddPoint(5);
            return;
        }
        if(hit == true)
            return;
        Debug.Log(collision.name);
        for(int i = 0; i < DisappearOnHit.Length; ++i){
            DisappearOnHit[i].SetActive(false);
        }
        for(int i = 0; i < AppearOnHit.Length; ++i){
            AppearOnHit[i].SetActive(true);
        }
        hit = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
