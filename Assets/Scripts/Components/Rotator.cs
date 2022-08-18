using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] float speed = 1;

    public Direction direction;
    public Method method;


    Rigidbody _rigidbody;

    public enum Direction
    {
        YLeft,
        YRight,
        ZLeft,
        ZRight
    }
    public enum Method
    {
        Rigidbody,
        Transform
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        switch (direction)
        {
            case Direction.ZLeft:
                switch (method)
                {
                    case Method.Rigidbody:
                        _rigidbody.angularVelocity = Vector3.forward * speed;
                        break;
                    case Method.Transform:
                        transform.Rotate(Vector3.forward * speed);
                        break;
                    default:
                        break;
                }
                break;
            case Direction.ZRight:
                switch (method)
                {
                    case Method.Rigidbody:
                        _rigidbody.angularVelocity = Vector3.back * speed;
                        break;
                    case Method.Transform:
                        transform.Rotate(Vector3.back * speed);
                        break;
                    default:
                        break;
                }
                break;
            case Direction.YLeft:
                switch (method)
                {
                    case Method.Rigidbody:
                        _rigidbody.angularVelocity = Vector3.down * speed;
                        break;
                    case Method.Transform:
                        transform.Rotate(Vector3.down * speed);
                        break;
                    default:
                        break;
                }
                break;
            case Direction.YRight:
                switch (method)
                {
                    case Method.Rigidbody:
                        _rigidbody.angularVelocity = Vector3.up * speed;
                        break;
                    case Method.Transform:
                        transform.Rotate(Vector3.up * speed);
                        break;
                    default:
                        break;
                }
                break;
            default:
                break;
        }
    }

}
