using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    private string _horizontalInputName = "Horizontal";
    private string _verticalInputName = "Vertical";

    private MoveController _moveController;

    private Vector3 _inputAxis;

    private bool _isMoving = false;


    private void Awake()
    {
        _moveController = GetComponent<MoveController>();
    }

    private void Update()
    {
        ReadInput();
    }

    private void FixedUpdate()
    {
        HandleInput();
    }

    private void ReadInput()
    {
        _inputAxis = new Vector3(Input.GetAxisRaw(_horizontalInputName), 0, Input.GetAxisRaw(_verticalInputName));

        if (_inputAxis != Vector3.zero)
            _isMoving = true;
        else
            _isMoving = false;
    }

    private void HandleInput()
    {
        if (_isMoving)
        {
            _moveController.MoveTo(_inputAxis);
            _moveController.RotateWithPower(_inputAxis);
            _isMoving = false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + _inputAxis);
    }
}
