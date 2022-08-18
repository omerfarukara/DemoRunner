using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour, ILevelState, IGameState
{
    [SerializeField] Transform frontOfTheWall;
    [SerializeField] float moveTheWallDuration;


    PlayerMovement _playerMovement;
    MovementData _movementData;
    Rigidbody _rigidbody;
    Animator _animator;


    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _animator = GetComponentInChildren<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
        _movementData = GetComponentInChildren<PlayerMovement>().movementData;
    }

    void Start()
    {
        AddListener();
    }

    private void OnEnable()
    {
        _movementData.HorizontalSpeed = 10;
    }

    private void OnDisable()
    {
        RemoveListener();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Constants.Tags.SEA))
        {
            transform.position = Vector3.zero;
        }
        if (other.gameObject.CompareTag(Constants.Tags.FINISH))
        {
            GameController.Instance.GetLevelState = LevelState.Paint;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag(Constants.Tags.ROTATING_PLATFORM))
        {
            _playerMovement.OnRotatingPlatform = true;
        }
        else
        {
            _playerMovement.OnRotatingPlatform = false;
        }

    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.CompareTag(Constants.Tags.ROTATING_PLATFORM))
        {
            _movementData.HorizontalSpeed = 5;
            if (collision.gameObject.GetComponent<Rotator>().direction == Rotator.Direction.ZLeft)
            {
                _rigidbody.AddForce(Vector3.left * 200);
            }
            else if (collision.gameObject.GetComponent<Rotator>().direction == Rotator.Direction.ZRight)
            {
                _rigidbody.AddForce(Vector3.right * 200);
            }
        }
    }

    void Update()
    {

    }

    public void AddListener()
    {
        EventManager.Instance.OnPaint += PaintHandler;
        EventManager.Instance.OnPlay += GamePlayHandler;
        EventManager.Instance.OnPause += GamePauseHandler;
        EventManager.Instance.OnVictory += GameVictoryHandler;
        EventManager.Instance.OnLoss += GameLossHandler;
    }

    public void RemoveListener()
    {
        EventManager.Instance.OnPaint -= PaintHandler;
        EventManager.Instance.OnPlay -= GamePlayHandler;
        EventManager.Instance.OnPause -= GamePauseHandler;
        EventManager.Instance.OnVictory -= GameVictoryHandler;
        EventManager.Instance.OnLoss -= GameLossHandler;
    }

    #region Listener Methods

    public void PaintHandler()
    {
        GameController.Instance.GameState = GameState.Pause;
        transform.DOMove(frontOfTheWall.position, moveTheWallDuration).OnComplete(
            () =>
            {
                GameController.Instance.CameraChange();
                transform.DORotate(new Vector3(0, -90, 0), moveTheWallDuration / 3).OnComplete(
                () =>
                    _animator.SetTrigger(Constants.Animations.IDLE));
            });
    }

    public void GamePlayHandler()
    {
        _animator.SetTrigger(Constants.Animations.RUN);
    }

    public void GamePauseHandler()
    {

    }

    public void GameVictoryHandler()
    {
        transform.DORotate(Vector3.up * 90, 1f);
        _animator.SetTrigger(Constants.Animations.VICTORY);
    }

    public void GameLossHandler()
    {

    }
    void Finish()
    {

    }
    #endregion
}
