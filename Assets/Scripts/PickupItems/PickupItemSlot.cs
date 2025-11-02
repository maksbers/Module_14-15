using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItemSlot : MonoBehaviour
{
    private PickupItem _item;

    public PickupItem Item { get; private set; }

    public void SetItem(PickupItem item)
    {
        Item = item;
    }
}
