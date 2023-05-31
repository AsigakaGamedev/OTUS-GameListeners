using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState { Off, Active, Paused }
public class GameManager : MonoBehaviour
{
    [Space]
    [SerializeField] private GameState state;

    private List<IGameListener> listeners;

    public static GameManager Instance;

    public GameState State { get => state; }

    private void Awake()
    {
        Instance = this;

        listeners = new List<IGameListener>();
        GameObject[] gameObjects = FindObjectsOfType<GameObject>(true);
        foreach (GameObject gameObject in gameObjects)
        {
            IGameListener listener = gameObject.GetComponent<IGameListener>();
            if (listener != null)
            {
                AddListener(listener);
            }
        }
    }

    private void Update()
    {
        if (state != GameState.Active) return;

        foreach (IGameListener listener in listeners)
        {
            if (listener == null)
            {
                listeners.Remove(listener);
                continue;
            }

            if (listener is IGameUpdateListener updateListener) updateListener.OnGameUpdate();
        }
    }

    private void FixedUpdate()
    {
        if (state != GameState.Active) return;

        foreach (IGameListener listener in listeners)
        {
            if (listener == null)
            {
                listeners.Remove(listener);
                continue;
            }

            if (listener is IGameUpdateListener fixedUpdateListener) fixedUpdateListener.OnGameFixedUpdate();
        }
    }

    public void StartGame()
    {
        if (state != GameState.Off) return;

        foreach (IGameListener listener in listeners)
        {
            if (listener == null)
            {
                listeners.Remove(listener);
                continue;
            }

            if (listener is IGameStartListener startListener) startListener.OnGameStart();
        }

        state = GameState.Active;
        Time.timeScale = 1;
    }

    public void EndGame()
    {
        if (state == GameState.Off) return;

        foreach (IGameListener listener in listeners)
        {
            if (listener == null)
            {
                listeners.Remove(listener);
                continue;
            }

            if (listener is IGameFinishListener endListener) endListener.OnGameFinish();
        }

        print("Игра завершена");
        state = GameState.Off;
    }

    public void PauseGame()
    {
        if (state == GameState.Paused || state == GameState.Off) return;

        foreach (IGameListener listener in listeners)
        {
            if (listener == null)
            {
                listeners.Remove(listener);
                continue;
            }

            if (listener is IGameRefreshListener pauseListener) pauseListener.OnGamePause();
        }

        state = GameState.Paused;
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        if (state != GameState.Paused || state == GameState.Off) return;

        foreach (IGameListener listener in listeners)
        {
            if (listener == null)
            {
                listeners.Remove(listener);
                continue;
            }

            if (listener is IGameStartListener startListener) startListener.OnGameStart();
        }

        state = GameState.Active;
        Time.timeScale = 1;
    }

    public void AddListener(IGameListener listener)
    {
        if (listeners.Contains(listener)) return;

        listeners.Add(listener);
    }

    public void RemoveListener(IGameListener listener)
    {
        if (!listeners.Contains(listener)) return;

        listeners.Remove(listener);
    }
}
