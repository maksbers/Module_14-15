using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpeedUp : PickupItem
{
    [SerializeField] private float _speedMultiplyAmount = 6f;
    [SerializeField] private float _rotationSpeedMultiplyAmount = 2f;

    public override void ApplyTo(Ship ship)
    {
        base.ApplyTo(ship);

        ship.MultiplySpeed(_speedMultiplyAmount);
        ship.MultiplyRotationSpeed(_rotationSpeedMultiplyAmount);
    }
}
