using UnityEngine;

public class AmmoSpawner : MonoBehaviour
{
    public GameObject coinPrefab;
    public GameObject spawnPointsContainer; // Assign the GameObject containing empty points
    public int numberOfAmmo = 100;
    public float maxHeightDifference = 0.0f; 
    public float desiredHeightAboveTerrain = 1.0f;

    void Start()
    {
        SpawnCoin();
    }

    void SpawnCoin()
    {
        if (spawnPointsContainer == null)
        {
            Debug.LogError("Spawn points container not assigned!");
            return;
        }

        Transform[] spawnPoints = spawnPointsContainer.GetComponentsInChildren<Transform>();

        for (int i = 0; i < numberOfAmmo && i < spawnPoints.Length; i++)
        {
            Vector3 spawnPoint = spawnPoints[i].position;
            spawnPoint.y = GetAdjustedHeightFromTerrain(spawnPoint);

            Instantiate(coinPrefab, spawnPoint, Quaternion.identity);
        }
    }

    float GetAdjustedHeightFromTerrain(Vector3 position)
    {
        if (Physics.Raycast(position + Vector3.up * 20f, Vector3.down, out RaycastHit hit, 50f))  // Increased raycast distance
        {
            if (hit.collider.gameObject.GetComponent<Terrain>()) // Check for Terrain
            {
                return hit.point.y + desiredHeightAboveTerrain;
            }
        }
        // Fallback in case raycast doesn't hit the terrain:
        Debug.LogWarning("Raycast didn't hit the terrain. Spawning ammo at original height.");
        return position.y; 
    }
}
