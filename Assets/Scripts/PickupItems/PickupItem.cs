using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PickupItem : MonoBehaviour
{
    private PickupFxHolder _particlesHolder;
    private ParticlesRunner _particlesRunner;

    private SphereCollider _collider;
    private Platform _ownerPlatform;

    protected float LifeTimeIdle = 7;

    private float _lifeTimer;
    private bool _isCollected;


    private void Awake()
    {
        _collider = GetComponent<SphereCollider>();
        _particlesRunner = GetComponent<ParticlesRunner>();

        _particlesHolder = GetComponentInChildren<PickupFxHolder>();

        _particlesRunner.RunParticles(_particlesHolder.Born, _particlesHolder.transform);
    }

    private void Update()
    {
        if (_isCollected == false)
        {
            SelfDestroyTimer();
        }
    }

    public void SetOwnerPlatform(Platform platform)
    {
        _ownerPlatform = platform;
        platform.Activate();
    }

    private void SelfDestroyTimer()
    {
        _lifeTimer += Time.deltaTime;

        if (_lifeTimer > LifeTimeIdle)
        {
            _particlesRunner.RunParticles(_particlesHolder.SelfDestroy, _particlesHolder.transform);

            DestroyItem();
        }  
    }

    public virtual void OnCollected()
    {
        _particlesRunner.RunParticles(_particlesHolder.Collect, _particlesHolder.transform);

        _collider.enabled = false;
        _isCollected = true;
        _ownerPlatform.Deactivate();
    }

    public virtual void ApplyTo(Ship ship)
    {
        _particlesRunner.RunParticles(_particlesHolder.Apply, _particlesHolder.transform);
    }

    public void DestroyItem()
    {
        if (_ownerPlatform.IsActive == true)
            _ownerPlatform.Deactivate();

        Destroy(this.gameObject);
    }
}
