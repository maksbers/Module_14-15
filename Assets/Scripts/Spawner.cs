using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] private List<PickupItem> _pickupItemPrefabs;

    [SerializeField] private float _spawnSpeed = 2;
    [SerializeField] private int _initialItemsCount = 3;

    private void Awake()
    {
        GenerateInitialItems();
    }

    private void GenerateInitialItems()
    {
        for (int i = 0; i < _initialItemsCount; i++ )
        {
            Vector3 spawnPosition = GenerateSpawnCoordinates();
            SpawnItemIn(spawnPosition);
        }
    }

    private void RunGenerationByTimer()
    {

    }

    private void SpawnItemIn(Vector3 spawnPoint)
    {
        PickupItem item = GenerateItem();
        Instantiate(item, spawnPoint, Quaternion.identity);
    }

    private PickupItem GenerateItem()
    {
        int randomIndex = Random.Range(0, _pickupItemPrefabs.Count);

        PickupItem item = _pickupItemPrefabs[randomIndex];

        return item;
    }

    private Vector3 GenerateSpawnCoordinates()
    {
        int randomIndex = Random.Range(0, _spawnPoints.Count);

        Vector3 spawnPoint = _spawnPoints[randomIndex].position;

        return spawnPoint;
    }
}
