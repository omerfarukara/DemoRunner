using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AIController : MonoBehaviour, ILevelState, IGameState
{
    [SerializeField] float finishYEndValue, finishYMoveDuration;

    MovementData _movementData;
    AIMovement _aiMovement;

    Rigidbody _rigidbody;
    Animator _animator;

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        _aiMovement = GetComponent<AIMovement>();
        _rigidbody = GetComponent<Rigidbody>();
        _movementData = GetComponent<AIMovement>().movementData;
    }

    void Start()
    {
        AddListener();
    }

    private void OnDisable()
    {
        RemoveListener();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag(Constants.Tags.OBSTACLE))
        {
            _aiMovement.Reset();
        }
        if (collision.collider.CompareTag(Constants.Tags.ROTATING_PLATFORM))
        {
            _aiMovement.OnRotatingPlatform = true;
        }
        if (collision.collider.CompareTag(Constants.Tags.NORMAL_PLATFORM))
        {
            _rigidbody.velocity = Vector3.zero;
        }

    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.CompareTag(Constants.Tags.ROTATING_PLATFORM))
        {
            _movementData.HorizontalSpeed = 5;
            if (collision.gameObject.GetComponent<Rotator>().direction == Rotator.Direction.ZLeft)
            {
                _rigidbody.AddForce(Vector3.left * 150);
            }
            else if (collision.gameObject.GetComponent<Rotator>().direction == Rotator.Direction.ZRight)
            {
                _rigidbody.AddForce(Vector3.right * 150);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(Constants.Tags.FINISH))
        {
            gameObject.SetActive(false);
        }

    }

    public void AddListener()
    {
        EventManager.Instance.OnPaint += PaintHandler;
        EventManager.Instance.OnPlay += GamePlayHandler;
        EventManager.Instance.OnPause += GamePauseHandler;
        EventManager.Instance.OnLoss += GameLossHandler;
    }

    public void RemoveListener()
    {
        EventManager.Instance.OnPaint -= PaintHandler;
        EventManager.Instance.OnPlay -= GamePlayHandler;
        EventManager.Instance.OnPause -= GamePauseHandler;
        EventManager.Instance.OnLoss -= GameLossHandler;
    }
    public void PaintHandler()
    {
        Destroy(gameObject);
    }

    public void GamePlayHandler()
    {
        _animator.SetTrigger(Constants.Animations.RUN);
    }

    public void GamePauseHandler()
    {
        throw new System.NotImplementedException();
    }

    public void GameLossHandler()
    {
        _animator.SetTrigger(Constants.Animations.VICTORY);
    }

    public void GameVictoryHandler()
    {
        throw new System.NotImplementedException();
    }
}
