using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _rotationSpeed = 10f;

    public float MoveSpeed => _moveSpeed;
    public float RotationSpeed => _rotationSpeed;
}
