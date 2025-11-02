using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : PickupItem
{
    public override void ApplyTo(Ship ship)
    {
        ship.Gun.Shoot();
    }
}
