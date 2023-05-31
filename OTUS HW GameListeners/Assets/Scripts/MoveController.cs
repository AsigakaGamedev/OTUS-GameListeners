using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class MoveController : MonoBehaviour, IGameStartListener, IGameFinishListener, IGameRefreshListener, IGameUpdateListener
{
    [SerializeField] private float forwardMoveSpeed = 4;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float jumpDistance;

    private KeyboardInputs inputs;
    private int curLineIndex;
    private int linesAmount = 3;

    public void OnGameStart()
    {
        inputs = FindAnyObjectByType<KeyboardInputs>(); //ƒа € использовал эту страшную шутку, так же можно?(
        inputs.onLeftMove += OnLeftMove;
        inputs.onRightMove += OnRightMove;
    }

    public void OnGamePause()
    {
        enabled = false;
    }

    public void OnGameResume()
    {
        enabled = true;
    }

    public void OnGameUpdate()
    {

    }

    public void OnGameFixedUpdate()
    {
        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, forwardMoveSpeed);
    }

    private void OnLeftMove()
    {
        if (curLineIndex <= 0) return;

        curLineIndex--;
        transform.position += new Vector3(-jumpDistance, 0, 0);
    }

    private void OnRightMove()
    {
        if (curLineIndex >= linesAmount) return;

        curLineIndex++;
        transform.position += new Vector3(jumpDistance, 0, 0);
    }

    public void OnGameFinish()
    {
        inputs.onLeftMove -= OnLeftMove;
        inputs.onRightMove -= OnRightMove;
    }
}
