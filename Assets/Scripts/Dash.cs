using UnityEngine;
using UnityEngine.Events;

public class Dash : MonoBehaviour
{
    [SerializeField]
    private float duration = 0.5f;
    [SerializeField] 
    private float InactiveDuration = 2f;    
    private UnityEvent onDash;
    [SerializeField]
    private UnityEvent onStopDash;
    private bool canDash = true;
    private bool isDashing;
    
    public bool IsDashing { get => isDashing; }
    public void DashAction()
    {
        if (!isDashing && canDash)
        {

            canDash = false;
            onDash?.Invoke();
            isDashing = true;
            Invoke(nameof(StopDash), duration);
        }
    }
    private void StopDash()
    {
        
        onStopDash?.Invoke();
        isDashing = false;
        Invoke(nameof(EnableDash), InactiveDuration);
    }
    private void EnableDash()
    {
        canDash = true;
    }
}
