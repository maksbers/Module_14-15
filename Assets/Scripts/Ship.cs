using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    private Gun _gun;

    [SerializeField] private ParticleSystem _particleHealth;
    [SerializeField] private ParticleSystem _particleSpeed;
    [SerializeField] private Transform _particleBurnPoint;

    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _moveSpeedMax = 15f;

    [SerializeField] private float _rotationSpeed = 2f;
    [SerializeField] private float _rotationSpeedMax = 6f;

    [SerializeField] private float _health = 50;

    public float MoveSpeed => _moveSpeed;
    public float RotationSpeed => _rotationSpeed;
    public float Health => _health;
    public Gun Gun => _gun;


    private void Awake()
    {
        _gun = GetComponentInChildren<Gun>();
    }

    private void RunParticles(ParticleSystem particles, Transform transform)
    {
        ParticleSystem particlesInstance = Instantiate(particles, transform.position, transform.rotation, null);
        particlesInstance.Play();
    }

    public void IncreaseHealth(float value)
    {
        _health += value;

        RunParticles(_particleHealth, _particleBurnPoint);

        if (_health < 0)
            _health = 0;
    }

    public void MultiplySpeed(float amount)
    {
        _moveSpeed *= amount;

        RunParticles(_particleSpeed, _particleBurnPoint);

        if (_moveSpeed < 0)
            _moveSpeed = 0;

        SetSpeedLimits();
    }

    private void SetSpeedLimits()
    {
        if (_moveSpeed >= _moveSpeedMax)
            _moveSpeed = _moveSpeedMax;

        if (_rotationSpeed >= _rotationSpeedMax)
            _rotationSpeed = _rotationSpeedMax;
    }

    public void MultiplyRotationSpeed(float amount)
    {
        _rotationSpeed *= amount;

        if (RotationSpeed < 0)
            _rotationSpeed = 0;
    }
}
