using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] Transform _muzzle;
    [SerializeField] Bullet _bulletPrefab;
    [SerializeField] float _shootPower = 1f;

    public void Shoot()
    {
        Bullet _bullet = Instantiate(_bulletPrefab, _muzzle.transform.position, _muzzle.transform.rotation);

        Rigidbody rigidBody = _bullet.GetComponent<Rigidbody>();
        rigidBody.velocity = _muzzle.forward * _shootPower;
    }
}
