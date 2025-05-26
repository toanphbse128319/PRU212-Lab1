using UnityEngine;
using VolumetricLines;

public class Lazer : MonoBehaviour
{
    public GameObject LazerLine;
    public VolumetricLineBehavior Line;
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
                start = new Vector3(start.x, 0, start.z);
                Line.StartPos = start;
                LazerLine.SetActive(true);
            }
        } else if(Input.GetKeyUp(KeyCode.Space)) {
            if(LazerLine.activeSelf == true){
                start = new Vector3(start.x, 0, start.z);
                Line.StartPos = start;
                LazerLine.SetActive(false);
            }
        }
    }

}
