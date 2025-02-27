using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private UnityEvent onGameStart;

    private void Start()
    {
        onGameStart?.Invoke();
    }
}
