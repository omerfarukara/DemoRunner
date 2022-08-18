using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class GameController : MonoSingleton<GameController>
{
    GameState gameState = GameState.Pause;

    [SerializeField] Cinemachine.CinemachineVirtualCamera vcam;
    [SerializeField] Vector3 paintCamRot;
    [SerializeField] float paintCamPosDuration;
    [SerializeField] Text percent;

    public GameState GameState
    {
        get
        {
            return gameState;
        }
        set
        {
            gameState = value;
            switch (gameState)
            {
                case GameState.Pause:
                    EventManager.Instance.OnPause?.Invoke();
                    break;
                case GameState.Play:
                    EventManager.Instance.OnPlay?.Invoke();
                    break;
                case GameState.Loss:
                    EventManager.Instance.OnLoss?.Invoke();
                    break;
                case GameState.Victory:
                    EventManager.Instance.OnVictory?.Invoke();
                    break;
                default:
                    break;
            }
        }
    }

    LevelState levelState = LevelState.Run;

    public LevelState GetLevelState
    {
        get
        {
            return levelState;
        }
        set
        {
            levelState = value;

            switch (levelState)
            {
                case LevelState.Run:
                    break;
                case LevelState.Paint:
                    EventManager.Instance.OnPaint?.Invoke();
                    break;
                default:
                    break;
            }
        }
    }

    private void Awake()
    {
        Singleton();
    }

    public bool GetPlayability()
    {
        return gameState == GameState.Play;
    }

    public void CameraChange()
    {
        vcam.transform.DORotate(paintCamRot, paintCamPosDuration);
        vcam.GetCinemachineComponent<Cinemachine.CinemachineFramingTransposer>().m_TrackedObjectOffset = new Vector3(0, 10, -12.25f);
    }

    private void Update()
    {
        if (percent.text == "100" && GameState != GameState.Victory)
        {
            GameState = GameState.Victory;
            vcam.GetCinemachineComponent<Cinemachine.CinemachineFramingTransposer>().m_TrackedObjectOffset = new Vector3(0, 3, 2f);
        }
    }
}
