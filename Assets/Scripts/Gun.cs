using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] Transform _muzzle;
    [SerializeField] Bullet _bulletPrefab;

    [SerializeField] private ParticleSystem _particleShoot;
    [SerializeField] private Transform _particleBurnPoint;
    private ParticlesRunner _particlesRunner;

    [SerializeField] float _shootPower = 1f;


    private void Awake()
    {
        _particlesRunner = GetComponent<ParticlesRunner>();
    }

    public void Shoot()
    {
        Bullet _bullet = Instantiate(_bulletPrefab, _muzzle.transform.position, _muzzle.transform.rotation);

        _particlesRunner.RunParticles(_particleShoot, _particleBurnPoint);

        Rigidbody rigidBody = _bullet.GetComponent<Rigidbody>();
        rigidBody.velocity = _muzzle.forward * _shootPower;
    }
}
