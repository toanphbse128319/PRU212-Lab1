using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    public Vector2 SpeedRange = Vector2.zero; // Randomized 2D speed
    public int rotation;                      // Randomized angle

    // Range limits for SpeedRange components
    public float minX = -5f;
    public float maxX = 5f;
    public float minY = -5f;
    public float maxY = 5f;

    // Range limits for rotation
    public int minRotation = 0;
    public int maxRotation = 360;
    public float smooth = 180f;
    void Start()
    {
        RandomizeValues();
        Debug.Log($"Randomized Speed: {SpeedRange}, Rotation: {rotation}");
    }

    public void Update()
    {
        // Move the asteroid based on the randomized speed
        transform.Translate(SpeedRange * Time.deltaTime, Space.World);
        // Rotate the asteroid around its own axis
        Vector3 rotationAxis = new Vector3(0, 0, 1);
        transform.Rotate(rotationAxis, rotation * Time.deltaTime * smooth);
    }

    public void RandomizeValues()
    {
        // Randomize SpeedRange as a Vector2 direction
        float x = Random.Range(minX, maxX);
        float y = Random.Range(minY, maxY);
        SpeedRange = new Vector2(x, y);

        // Randomize rotation as an integer
        rotation = Random.Range(minRotation, maxRotation + 1); // inclusive max
    }
}
