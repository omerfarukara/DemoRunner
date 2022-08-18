using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameState
{
    public void GamePlayHandler();
    public void GamePauseHandler();
    public void GameVictoryHandler();
    public void GameLossHandler();

    public void AddListener();
    public void RemoveListener();
}
