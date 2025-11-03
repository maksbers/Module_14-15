using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupCollector : MonoBehaviour
{
    [SerializeField] private Transform _pickupPoint;

    private PickupItem _item;

    [SerializeField] private float _pickupSpeed = 5f;

    public bool _isPickingUp = false;
    private bool _isSlotAvailable = true;

    public PickupItem Item => _item;


    private void Update()
    {
        if (_isPickingUp)
        {
            MoveItemToPickupPoint(_item);
        }
    }

    private void MoveItemToPickupPoint(PickupItem pickupItem)
    {
        Vector3 direction = Vector3.Slerp(pickupItem.transform.position, _pickupPoint.position, _pickupSpeed * Time.deltaTime);
        pickupItem.transform.position = direction;

        float distance = Vector3.Distance(pickupItem.transform.position, _pickupPoint.position);

        if (distance < 0.1f)
        {
            _isPickingUp = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_isSlotAvailable == false)
            return;

        if (other.TryGetComponent<PickupItem>(out PickupItem pickupItem))
        {
            HandlePickup(pickupItem);
        }
    }

    public void HandlePickup(PickupItem pickupItem)
    {
        if (_isPickingUp == true || _isSlotAvailable == false)
            return;

        _isPickingUp = true;
        _isSlotAvailable = false;

        _item = pickupItem;
        _item.transform.SetParent(_pickupPoint);
        _item.OnCollected();
    }

    public void ClearItem()
    {
        if (_item != null)
        {
            _item.DestroyItem();
        }

        _isPickingUp = false;
        _isSlotAvailable = true;
        _item = null;
    }
}
