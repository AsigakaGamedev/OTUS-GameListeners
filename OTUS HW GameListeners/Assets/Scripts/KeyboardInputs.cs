using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInputs : MonoBehaviour, IGameUpdateListener
{
    public Action onLeftMove;
    public Action onRightMove;

    public void OnGameUpdate()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow)) onLeftMove?.Invoke();

        if (Input.GetKeyDown(KeyCode.RightArrow)) onRightMove?.Invoke();
    }

    public void OnGameFixedUpdate()
    {

    }
}
