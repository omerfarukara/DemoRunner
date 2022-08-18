using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class UIController : MonoSingleton<UIController>
{
    [Header("Panels")]
    [SerializeField] GameObject startPanel;
    [SerializeField] GameObject gamePanel;
    [SerializeField] GameObject lossPanel;
    [SerializeField] GameObject victoryPanel;

    [Header("Buttons")]
    [SerializeField] Button startButton;
    [SerializeField] Button restartButton;

    [Header("Joystick")]
    [SerializeField] DynamicJoystick dynamicJoystick;


    [Header("OrderPlayers")]
    public TextMeshProUGUI firstPlayer, secondPlayer, thirdPlayer, fourthPlayer, fiftPlayer,
        sixtPlayer, seventhPlayer, eighthPlayer, ninthPlayer, tenthPlayer, eleventhPlayer;
    private void Awake()
    {
        Singleton(false);
        startButton.onClick.AddListener(StartGame);
        restartButton.onClick.AddListener(RestartGame);
    }
    private void Start()
    {
        AddListener();
    }
    private void OnDisable()
    {
        RemoveListener();
    }

    public void AddListener()
    {
        EventManager.Instance.OnPaint += PaintHandler;
        EventManager.Instance.OnVictory += WinHandler;
    }

    public void RemoveListener()
    {
        EventManager.Instance.OnPaint -= PaintHandler;
    }

    void StartGame()
    {
        GameController.Instance.GameState = GameState.Play;
        startPanel.SetActive(false);
    }

    public void RestartGame()
    {
        GameManager.Instance.PlayGame();
    }

    void WinHandler()
    {
        victoryPanel.SetActive(true);
    }

    private void PaintHandler()
    {
        dynamicJoystick.gameObject.SetActive(false);
    }

    public Vector2 GetJoystick()
    {
        return dynamicJoystick.Direction;
    }

    public float GetHorizontal()
    {
        return dynamicJoystick.Horizontal;
    }

    public float GetVertical()
    {
        return dynamicJoystick.Vertical;
    }
}
