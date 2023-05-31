using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UILevelScreen : MonoBehaviour, IGameStartListener, IGameRefreshListener
{
    [SerializeField] private Button startGameBtn;
    [SerializeField] private Button pauseGameBtn;
    [SerializeField] private Button resumeGameBtn;

    [Space]
    [SerializeField] private TextMeshProUGUI timerText;

    [Space]
    [SerializeField] private GameInvoker gameInvoker;

    private GameManager gameManager;

    private void OnEnable()
    {
        startGameBtn.onClick.AddListener(OnStartGameClick);
        pauseGameBtn.onClick.AddListener(OnPauseBtnClick);
        resumeGameBtn.onClick.AddListener(OnResumeBtnClick);
    }

    private void OnDisable()
    {
        startGameBtn.onClick.RemoveListener(OnStartGameClick);
        pauseGameBtn.onClick.RemoveListener(OnPauseBtnClick);
        resumeGameBtn.onClick.RemoveListener(OnResumeBtnClick);
    }

    private void OnStartGameClick()
    {
        timerText.gameObject.SetActive(true);
        startGameBtn.gameObject.SetActive(false);
        gameInvoker.StartGameByDelay(3);
        StartCoroutine(EStartTimer());
    }

    private IEnumerator EStartTimer()
    {
        float curTime = 3;

        while (curTime > 0)
        {
            curTime--;
            timerText.text = curTime.ToString();
            yield return new WaitForSeconds(1);
        }
    }

    private void OnPauseBtnClick() => gameManager.PauseGame();
    private void OnResumeBtnClick() => gameManager.ResumeGame();

    public void OnGamePause()
    {
        pauseGameBtn.gameObject.SetActive(false);
        resumeGameBtn.gameObject.SetActive(true);
    }

    public void OnGameResume()
    {
        pauseGameBtn.gameObject.SetActive(true);
        resumeGameBtn.gameObject.SetActive(false);
    }

    public void OnGameStart()
    {
        gameManager = GameManager.Instance;
        timerText.gameObject.SetActive(false);
        pauseGameBtn.gameObject.SetActive(true);
        resumeGameBtn.gameObject.SetActive(false);
    }
}
