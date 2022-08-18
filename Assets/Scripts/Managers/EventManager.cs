using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoSingleton<EventManager>
{
    public Action OnPlay;
    public Action OnPause;
    public Action OnLoss;
    public Action OnVictory;
    public Action OnPaint;

    private void Awake()
    {
        Singleton(true);
    }

}
