using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    [SerializeField] private Ship _ship;

    private Rigidbody _rigidbody;


    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void MoveTo(Vector3 direction)
    {
        Vector3 moveVector = direction.normalized * _ship.MoveSpeed * Time.deltaTime;
        _rigidbody.AddForce(moveVector, ForceMode.Force);
    }

    public void RotateWithLerp(Vector3 direction)
    {
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, _ship.RotationSpeed * Time.deltaTime);
    }

    public void RotateWithPower(Vector3 direction)
    {
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        _rigidbody.AddTorque(Vector3.Cross(transform.forward, direction.normalized) * _ship.RotationSpeed, ForceMode.Acceleration);
    }
}
