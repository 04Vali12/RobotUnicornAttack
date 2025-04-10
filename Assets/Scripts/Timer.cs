using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField]
    public Text textTimer;
    [SerializeField]
    private UnityEvent onSecondsPassed;
    
    private int currentSeconds;

    public void StartTimer(int startSeconds)
    {
        onSecondsPassed?.Invoke();
        currentSeconds --;
        textTimer.text = currentSeconds.ToString();
        if (currentSeconds <= 0)
        {
            Invoke("setTimer", 1f);
        }
    }
}
