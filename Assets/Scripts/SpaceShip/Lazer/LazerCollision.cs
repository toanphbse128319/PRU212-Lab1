using UnityEngine;
using VolumetricLines;

public class LazerCollision : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private BoxCollider2D box;
    private VolumetricLineBehavior line;
    private static bool collided = false;
    public float ExtendSpeed = 1.0f;

    void Start()
    {
        box = GetComponent<BoxCollider2D>();
        line = GetComponent<VolumetricLineBehavior>();
    }

    private void UpdateHitBox(Vector2 lineSize){
        line.StartPos = new Vector3(line.StartPos.x, lineSize.y, line.StartPos.z);
        box.size = lineSize;
        box.offset = new Vector2(box.offset.x, line.StartPos.y / 2);
    }
    // Update is called once per frame
    void Update()
    {
        if(gameObject.activeSelf == false || collided == true)
            return;
        if(line.StartPos.y > 5)
            return;
        Vector2 lineSize = new Vector2(box.size.x, line.StartPos.y + ExtendSpeed * Time.deltaTime);
        UpdateHitBox(lineSize);
    }

    void OnTriggerEnter2D(Collider2D other){
        if(gameObject.activeSelf == false || other.name == "Atom")
            return;
        collided = true;
        Vector2 currentPosition = transform.position;
        Vector2 closest = other.ClosestPoint(currentPosition);
        float distance = Vector2.Distance(currentPosition, closest);
        Vector2 lineSize = new Vector2(box.size.x, distance);
        UpdateHitBox(lineSize);
    }

    void OnTriggerExit2D(Collider2D other){
        collided = false;
    }
}
