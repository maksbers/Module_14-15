using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    private Rigidbody _rigidbody;


    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void MoveTo(Vector3 direction, float speed)
    {
        Vector3 moveVector = direction.normalized * speed * Time.deltaTime;
        _rigidbody.AddForce(moveVector, ForceMode.Force);
    }

    public void RotateWithPower(Vector3 direction, float speed)
    {
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        _rigidbody.AddTorque(Vector3.Cross(transform.forward, direction.normalized) * speed, ForceMode.Acceleration);
    }
}
