using UnityEngine;

public class Movement : MonoBehaviour
{
    public float velocity = 0.15f;
    public float limit = 1f;
    public float smooth = 5.0f;
    public SpriteRenderer spriteRenderer;
    public GameObject StopIfDisabled;
    public ParticleSystem engineSmoke;
    public float Decelerate = 0.05f;
    private Fuelbar _fuelbar;
    // 0: weak, 1: neutral, 2: strong;
    public Sprite[] sprites = new Sprite[3];
    private float Yspeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer.sprite = sprites[1];
        _fuelbar = GetComponentInChildren<Fuelbar>();
    }

    void ChangeFlameIntensity(int strength)
    {
        var emission = engineSmoke.emission;
        switch(strength){
            case  1: 
                spriteRenderer.sprite = sprites[2]; 
                emission.rateOverTime = 150f;
                break;
            case  0: 
                spriteRenderer.sprite = sprites[1]; 
                emission.rateOverTime = 20f;
                break;
            case -1: 
                emission.rateOverTime = 10f;
                spriteRenderer.sprite = sprites[0]; 
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(StopIfDisabled.activeSelf == false || _fuelbar.CurrentFuel <= 0){
            var emission = engineSmoke.emission;
            ChangeFlameIntensity(-1);
            emission.rateOverTime = 0f;
            if(StopIfDisabled.activeSelf == false)
                return;
        } else {
            ChangeFlameIntensity((int) Input.GetAxis("Vertical"));
            float x = -1 * Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical") * Time.deltaTime;
            if(Yspeed > limit){
                if(y < 0)
                    Yspeed += y;
            } else if( Yspeed < 0){
                if(y > 0)
                    Yspeed += y;
            } else{
                Yspeed += y;
            }
        }
        Yspeed -= Decelerate * Time.deltaTime;
        if(Yspeed < 0)
            Yspeed = 0;

        Vector3 movement = new Vector3(0, Yspeed, 0);
        // Rotate the cube by converting the angles into a quaternion.
        transform.Translate(movement * velocity );
        if( (int) Input.GetAxis("Horizontal") != 0 ){
            transform.Rotate(0, 0, -1 * Input.GetAxis("Horizontal") * Time.deltaTime * smooth);
        }
    }
}
