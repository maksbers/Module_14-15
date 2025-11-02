using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    private string _horizontalInputName = "Horizontal";
    private string _verticalInputName = "Vertical";

    private KeyCode _ApplyPickupItemKey = KeyCode.E;

    [SerializeField] private PickupCollector _pickupCollector;
    [SerializeField] private Ship _ship;

    private MoveController _moveController;

    private Vector3 _inputAxis;

    private bool _isMoving = false;
    private bool _isApplyingPickup = false;


    private void Awake()
    {
        _moveController = GetComponent<MoveController>();
    }

    private void Update()
    {
        ReadMoveInput();
        ReadApplyPickupInput();
    }

    private void FixedUpdate()
    {
        HandleMoveInput();
        HandleApplyPickupInput();
    }

    private void HandleApplyPickupInput()
    {
        if (_isApplyingPickup)
        {
            HandleApplyPickupItem();
            _isApplyingPickup = false;
        }
    }

    private void ReadApplyPickupInput()
    {
        if (Input.GetKeyDown(_ApplyPickupItemKey))
        {
            _isApplyingPickup = true;
        }
    }

    private void ReadMoveInput()
    {
        _inputAxis = new Vector3(Input.GetAxisRaw(_horizontalInputName), 0, Input.GetAxisRaw(_verticalInputName));

        if (_inputAxis != Vector3.zero)
            _isMoving = true;
        else
            _isMoving = false;
    }

    private void HandleMoveInput()
    {
        if (_isMoving)
        {
            _moveController.MoveTo(_inputAxis, _ship.MoveSpeed);
            _moveController.RotateWithPower(_inputAxis, _ship.RotationSpeed);
            _isMoving = false;
        }
    }

    private void HandleApplyPickupItem()
    {
        if (_pickupCollector.Item == null)
        {
            Debug.Log("No pickup item to apply");
            return;
        }

        _pickupCollector.Item.ApplyTo(_ship);
        _pickupCollector.ClearItem();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + _inputAxis);
    }
}
