using UnityEngine;

public class TrapSpawner : MonoBehaviour
{
    public GameObject[] trapPrefabs;
    public float spawnInterval = 5f; // 생성 간격
    private float timeSinceLastSpawn;
    public float spawnProbability = 0.8f; // % 확률로 생성 (0.8은 80% 확률을 의미)
    public float trapSpeed = 2f; // 장애물 이동 속도

    void Start()
    {
        Debug.Log("TrapSpawner Start");

        if (trapPrefabs == null || trapPrefabs.Length == 0)
        {
            Debug.LogWarning("The trapPrefabs array is empty. Unable to create obstacles.");
            return;
        }

        foreach (GameObject prefab in trapPrefabs)
        {
            if (prefab.GetComponent<Collider2D>() == null)
            {
                Debug.LogWarning("Prefab " + prefab.name + " does not have a Collider2D component.");
            }

            if (prefab.GetComponent<Rigidbody2D>() == null)
            {
                Debug.LogWarning("Prefab " + prefab.name + " does not have a Rigidbody2D component.");
            }
        }
    }

    void Update()
    {
        Debug.Log("TrapSpawner Update - GameObject Active: " + gameObject.activeSelf + ", Script Enabled: " + enabled);

        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= spawnInterval)
        {
            timeSinceLastSpawn = 0f;

            if (Random.value <= spawnProbability)
            {
                SpawnTrap();
            }
        }
    }

    public void SpawnTrap()
    {
        if (trapPrefabs == null || trapPrefabs.Length == 0)
        {
            Debug.LogWarning("The trapPrefabs array is empty. Unable to create obstacles.");
            return;
        }

        int randomIndex = Random.Range(0, trapPrefabs.Length);
        GameObject selectedPrefab = trapPrefabs[randomIndex];

        if (selectedPrefab == null)
        {
            Debug.LogWarning("Selected prefab is null. Unable to create obstacle.");
            return;
        }

        float randomX = Random.Range(-60f, 60f);
        Vector3 spawnPosition = new Vector3(randomX, -68, 0);

        GameObject trapInstance = Instantiate(selectedPrefab, spawnPosition, Quaternion.identity);
        Rigidbody2D rb = trapInstance.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = new Vector2(0, trapSpeed); // 위로 이동하는 속도 설정
        }
        else
        {
            Debug.LogWarning("Spawned trap does not have a Rigidbody2D component.");
        }

        Debug.Log("Spawned trap: " + trapInstance.name + " at position " + spawnPosition);
    }
}
