using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupRepair : PickupItem
{
    [SerializeField] private int RepairAmount = 10;

    public override void ApplyTo(Ship ship)
    {
        base.ApplyTo(ship);

        ship.IncreaseHealth(RepairAmount);
    }
}
