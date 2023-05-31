using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameManager))]
public class GameInvoker : MonoBehaviour
{
    private GameManager manager;
    private bool delayStarted;

    private void Awake()
    {
        manager = GetComponent<GameManager>();
    }

    public void StartGameByDelay(float delay)
    {
        if (delayStarted) return;

        delayStarted = true;
        Invoke(nameof(InvokeStartGame), delay);
    }

    private void InvokeStartGame() => manager.StartGame();
}
