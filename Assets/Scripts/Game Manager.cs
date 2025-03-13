using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private UnityEvent onGameStart;

    [SerializeField]
    private UnityEvent onRespawnGame;
    [SerializeField]
    private float secondsToRestart = 3f;

    [SerializeField]
    private UnityEvent onFinishGame;

    private float finalSecondsToRestart =5f;

    private void Start()
    {
        onGameStart?.Invoke();
    }
    public void RespawnGame()
    {
        Invoke(nameof(RestartGame), finalSecondsToRestart);
    }
    public void FinishGame()
    {
        onFinishGame?.Invoke();
        Invoke("StartGame", secondsToRestart);
        Invoke("RestartGame", finalSecondsToRestart);
    }
    private void RestartGame()
    {
        onRespawnGame?.Invoke();
    }
}
