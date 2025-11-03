using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class Spawner : MonoBehaviour
{
    private string _speedUpFlag = "SpeedUp";
    private string _repairFlag = "Repair";
    private string _shootFlag = "Shoot";

    [SerializeField] private PickupItem _speedUpPrefab;
    [SerializeField] private PickupItem _repairPrefab;
    [SerializeField] private PickupItem _shootPrefab;

    [SerializeField] private List<Platform> _platforms;
    [SerializeField] private List<PickupItem> _pickupItemPrefabs;

    [SerializeField] private float _cooldown = 7;
    [SerializeField] private int _initialItemsCount = 3;

    public float _timer;


    private void Start()
    {
        InitialSpawnItems();
    }

    private void Update()
    {
        SpawnWithTimer();
    }

    private void SpawnWithTimer()
    {
        _timer += Time.deltaTime;

        if (_timer >= _cooldown)
        {
            int freeIndex = GetFreePositionIndex();

            if (freeIndex != -1)
            {
                Vector3 spawnPosition = _platforms[freeIndex].transform.position;
                SpawnItemAt(spawnPosition, freeIndex);
            }

            _timer = 0f;
        }
    }

    private void SpawnItemAt(Vector3 spawnPoint, int parentIndex)
    {
        PickupItem item = GetRandomItem();
        PickupItem instance = Instantiate(item, spawnPoint, Quaternion.identity);

        Platform platform = _platforms[parentIndex];
        instance.SetOwnerPlatform(platform);

        SetIndicationFlag(item, platform);
    }

    private void SetIndicationFlag(PickupItem item, Platform platform)
    {
        if (item == _speedUpPrefab)
            platform.ActivateWithTrigger(_speedUpFlag);

        else if (item == _repairPrefab)
            platform.ActivateWithTrigger(_repairFlag);

        else if (item == _shootPrefab)
            platform.ActivateWithTrigger(_shootFlag);
    }

    private void InitialSpawnItems()
    {
        for (int i = 0; i < _initialItemsCount; i++ )
        {
            int freeIndex = GetFreePositionIndex();
            Vector3 spawnPosition = _platforms[freeIndex].transform.position;

            SpawnItemAt(spawnPosition, freeIndex);
        }
    }

    private int GetFreePositionIndex()
    {
        List<int> freePositionIndexes = new List<int>();

        for (int i = 0; i < _platforms.Count; i++)
        {
            bool isFree = (_platforms[i].IsActive == false);

            if (isFree)
                freePositionIndexes.Add(i);
        }

        if (freePositionIndexes.Count == 0)
            return -1;

        int randomFreePositionIndex = freePositionIndexes[Random.Range(0, freePositionIndexes.Count)];

        return randomFreePositionIndex;
    }

    private PickupItem GetRandomItem()
    {
        int index = Random.Range(0, _pickupItemPrefabs.Count);

        PickupItem item = _pickupItemPrefabs[index];
        return item;
    }
}
