using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILevelState
{
    public void PaintHandler();

    public void AddListener();
    public void RemoveListener();
}
