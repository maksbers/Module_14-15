using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleHit;

    private ParticlesRunner _particleRunner;

    [SerializeField] private float _lifeTime = 1f;


    private void Start()
    {
        _particleRunner = GetComponent<ParticlesRunner>();

        Destroy(gameObject, _lifeTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        _particleRunner.RunParticles(_particleHit, transform.position);

        Destroy(gameObject);
    }
}
