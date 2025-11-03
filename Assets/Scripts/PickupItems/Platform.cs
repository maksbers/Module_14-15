using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private string _activationFlag = "IsActive";

    [SerializeField] private ParticleSystem _particlesActivate;
    [SerializeField] private ParticleSystem _particlesDeactivate;
    [SerializeField] private Transform _particlesBurnPoint;

    [SerializeField] private GameObject _colorIndicator;
    private Animator _animator;

    private bool _isActive;
    public bool IsActive => _isActive;


    private void Awake()
    {
        _isActive = false;

        _animator = GetComponent<Animator>();
    }

    public void ActivateWithTrigger(string triggerName)
    {
        _isActive = true;
        _animator.SetTrigger(triggerName);
    }

    public void Activate()
    {
        _isActive = true;
        _animator.SetBool(_activationFlag, true);
    }

    public void Deactivate()
    {
        _isActive = false;
        _animator.SetBool(_activationFlag, false);
    }
}
