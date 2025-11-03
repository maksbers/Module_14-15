using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupShoot : PickupItem
{
    public override void ApplyTo(Ship ship)
    {
        base.ApplyTo(ship);

        ship.Gun.Shoot();
    }
}
