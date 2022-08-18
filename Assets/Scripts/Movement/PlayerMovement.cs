using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public MovementData movementData;

    bool onRotatingPlatform;

    Rigidbody _rigidbody;


    public bool OnRotatingPlatform
    {
        get
        {
            return onRotatingPlatform;
        }
        set
        {
            onRotatingPlatform = value;
        }
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Start()
    {

    }

    private void FixedUpdate()
    {
        if (!GameController.Instance.GetPlayability()) return;

        float horizontal = UIController.Instance.GetHorizontal();

        if (!onRotatingPlatform)
        {
            if (horizontal == 0)
            {
                _rigidbody.velocity = new Vector3(0, _rigidbody.velocity.y, movementData.VerticalSpeed);
            }
            else
            {
                _rigidbody.velocity = new Vector3(movementData.HorizontalSpeed * horizontal, _rigidbody.velocity.y, movementData.VerticalSpeed);
            }
        }
        else
        {
            _rigidbody.velocity = new Vector3((movementData.HorizontalSpeed * 1.5f) * horizontal, _rigidbody.velocity.y, movementData.VerticalSpeed);
        }
    }
}
