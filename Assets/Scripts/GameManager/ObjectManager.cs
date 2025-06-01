using UnityEngine;
using System.Collections.Generic;

public class ObjectManager : MonoBehaviour
{
    public GameObject[] objectsToDuplicate; // Array of different prefabs
    public Transform shipTransform;
    public int numberOfObjects = 10;
    public float spawnRadius = 50f;
    public float despawnDistance = 100f;
    public float minDistanceBetweenObjects = 10f;
    public int maxSpawnAttempts = 20;
    public Pause Pause;
    private List<GameObject> activeObjects = new List<GameObject>();
    private GameObject spawnLocation;
    void Start()
    {
        if (Pause.IsPaused == true)
            return;
        spawnLocation = GameObject.Find("AsteroidSpawner");
        for (int i = 0; i < numberOfObjects; i++)
        {
            Vector3 spawnPos = GetValidSpawnPosition();
            if (spawnPos != Vector3.zero)
            {
                GameObject prefab = GetRandomPrefab();
                GameObject obj = Instantiate(prefab, spawnPos, Quaternion.identity, spawnLocation.transform);
                obj.SetActive(true);
                obj.name = obj.name + "_" + i;
                activeObjects.Add(obj);
            }
        }
    }

    void Update()
    {
        if (Pause.IsPaused == true)
            return;
        for (int i = activeObjects.Count - 1; i >= 0; i--)
        {
            float distance = Vector3.Distance(activeObjects[i].transform.position, shipTransform.position);
            if (distance > despawnDistance)
            {
                Destroy(activeObjects[i]);
                Vector3 newSpawnPos = GetValidSpawnPosition();
                if (newSpawnPos != Vector3.zero)
                {
                    GameObject prefab = GetRandomPrefab();
                    GameObject newObj = Instantiate(prefab, newSpawnPos, Quaternion.identity, spawnLocation.transform);
                    newObj.name = newObj.name + "_" + i;
                    newObj.SetActive(true);
                    activeObjects[i] = newObj;
                }
                else
                {
                    activeObjects.RemoveAt(i);
                }
            }
        }
    }

    Vector3 GetValidSpawnPosition()
    {
        for (int attempt = 0; attempt < maxSpawnAttempts; attempt++)
        {
            Vector3 candidate = shipTransform.position + Random.onUnitSphere * spawnRadius;
            // Check if it's outside the camera view
            Vector3 viewportPos = Camera.main.WorldToViewportPoint(candidate);
            bool outsideCamera = viewportPos.x < 0 || viewportPos.x > 1 || viewportPos.y < 0 || viewportPos.y > 1;
            // Optional: only count valid if also outside camera
            if (outsideCamera)
            {
                bool isFarEnough = true;
                foreach (GameObject obj in activeObjects)
                {
                    if (Vector3.Distance(candidate, obj.transform.position) < minDistanceBetweenObjects)
                    {
                        isFarEnough = false;
                        break;
                    }
                }
                if (isFarEnough){
                    candidate.z = 0;
                    return candidate;
                }
            }
        }
        return Vector3.zero; // fallback if no valid position found
    }

    GameObject GetRandomPrefab()
    {
        if (objectsToDuplicate.Length == 0) return null;
        int index = Random.Range(0, objectsToDuplicate.Length);
        return objectsToDuplicate[index];
    }
}
