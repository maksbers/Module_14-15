using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : PickupItem
{
    [SerializeField] private float _speedMultiplyAmount = 6f;
    [SerializeField] private float _rotationSpeedMultiplyAmount = 2f;

    public override void ApplyTo(Ship ship)
    {
        ship.MultiplySpeed(_speedMultiplyAmount);
        ship.MultiplyRotationSpeed(_rotationSpeedMultiplyAmount);
    }
}
