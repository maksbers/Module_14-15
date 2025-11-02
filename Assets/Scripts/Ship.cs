using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    private Gun _gun;

    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _rotationSpeed = 2f;

    [SerializeField] private float _health = 50;

    public float MoveSpeed => _moveSpeed;
    public float RotationSpeed => _rotationSpeed;
    public float Health => _health;
    public Gun Gun => _gun;


    private void Awake()
    {
        _gun = GetComponentInChildren<Gun>();
    }

    public void IncreaseHealth(float value)
    {
        _health += value;

        if (_health < 0)
            _health = 0;
    }

    public void MultiplySpeed(float amount)
    {
        _moveSpeed *= amount;

        if (_moveSpeed < 0)
            _moveSpeed = 0;
    }

    public void MultiplyRotationSpeed(float amount)
    {
        _rotationSpeed *= amount;

        if (RotationSpeed < 0)
            _rotationSpeed = 0;
    }
}
