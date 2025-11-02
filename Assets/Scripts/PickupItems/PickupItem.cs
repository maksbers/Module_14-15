using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PickupItem : MonoBehaviour
{
    private SphereCollider _collider;

    private void Awake()
    {
        _collider = GetComponent<SphereCollider>();
    }

    public virtual void OnCollected()
    {
        _collider.enabled = false;
    }

    public abstract void ApplyTo(Ship ship);

    public void DestroyItem()
    {
        GameObject.Destroy(this.gameObject);
    }
}
