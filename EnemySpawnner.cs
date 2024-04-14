using System.Collections;
using UnityEngine;

public class EnemySpawnner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnRange = 5f;
    public int enemiesPerPoint = 5;
    public float heightOffset = 1f;

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            foreach (Transform spawnPoint in transform)
            {
                for (int i = 0; i < enemiesPerPoint; i++)
                {
                    SpawnEnemyAtPoint(spawnPoint);
                    yield return new WaitForSeconds(0.2f); // Delay between individual enemy spawns
                }
            }

            yield return new WaitForSeconds(5f); // Delay between spawn cycles
        }
    }

    void SpawnEnemyAtPoint(Transform spawnPoint)
    {
        Vector3 spawnPosition = spawnPoint.position + Random.insideUnitSphere * spawnRange;

        // Raycast to find terrain height
        RaycastHit hit;
        if (Physics.Raycast(spawnPosition + Vector3.up * 10f, Vector3.down, out hit, Mathf.Infinity))
        {
            // Ensure terrain is hit and use that position
            if (hit.collider.gameObject.CompareTag("Terrain"))
            {
                spawnPosition = hit.point + Vector3.up * heightOffset;

                // Instantiate enemy at the adjusted position
                GameObject newEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

                // Make sure the enemy aligns with the terrain normal
                Vector3 terrainNormal = hit.normal;
                newEnemy.transform.up = terrainNormal;
            }
        }
    }
}
