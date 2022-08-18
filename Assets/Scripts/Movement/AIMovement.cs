using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    public MovementData movementData;

    [SerializeField] float minRandomZ, maxRandomZ;
    [SerializeField] float speed;


    Vector3 point;

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

    private void Start()
    {
        point = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Constants.Tags.SEA))
        {
            Reset();
        }
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player") || collision.collider.CompareTag("Bot"))
        {
            Vector3 direction = transform.position - collision.transform.position;
            direction = Vector3.right * direction.x;
            collision.gameObject.GetComponent<Rigidbody>().AddForce(-direction * 50);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.CompareTag("Player") || collision.collider.CompareTag("Bot"))
        {
            Vector3 direction = transform.position - collision.transform.position;
            direction = Vector3.right * direction.x;
            collision.gameObject.GetComponent<Rigidbody>().AddForce(-direction * 10);
        }
    }

    private void FixedUpdate()
    {
        if (!GameController.Instance.GetPlayability()) return;

        if (Vector3.Distance(transform.position, point) < 1f)
        {
            SetRandomPoint();
        }

        Move();
    }

    void SetRandomPoint()
    {
        float x, z;

        if (transform.position.x > 0.1f)
        {
            x = Random.Range(movementData.HorizontalBounds.x, movementData.HorizontalBounds.y - transform.position.x);
            z = Random.Range(minRandomZ, maxRandomZ);
        }
        else
        {
            x = Random.Range(movementData.HorizontalBounds.x - transform.position.x, movementData.HorizontalBounds.y + 1);
            z = Random.Range(minRandomZ, maxRandomZ);
        }

        point.x = transform.position.x + x;
        point.z = transform.position.z + z;
    }

    void Move()
    {
        float x, z;

        if (!onRotatingPlatform)
        {
            x = Mathf.MoveTowards(transform.position.x, point.x, speed * Time.fixedDeltaTime);
            z = Mathf.MoveTowards(transform.position.z, point.z, speed * Time.fixedDeltaTime);
            Vector3 newPoint = new Vector3(x, _rigidbody.velocity.y, z);
            _rigidbody.MovePosition(newPoint);
        }
        else
        {
            if (transform.position.x > 0)
            {
                x = Random.Range(-3, 2);
                z = 1;
                point.x = x;
                point.z = z;
            }
            else
            {
                x = Random.Range(-1, 4);
                z = 1;
                point.x = x;
                point.z = z;

            }
            _rigidbody.velocity = new Vector3(x, _rigidbody.velocity.y, movementData.VerticalSpeed);
        }
    }

    public void Reset()
    {
        transform.position = Vector3.zero;
        SetRandomPoint();
    }
}
