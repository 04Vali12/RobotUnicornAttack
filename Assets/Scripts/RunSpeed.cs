using UnityEngine;

public class RunSpeed : MonoBehaviour
{
   [SerializeField]
   private float increaseValue = 0.1f;
   [SerializeField] 
   private float initialSpeedValue = 1f;

    [SerializeField]    
private Animator characterAnimator;

    private float speedValue = 1f;
    private bool isRuning = false;

    public void StartRunSpeed()
    {
       speedValue = initialSpeedValue;
       isRuning = true;
    } 

    public void StopRunSpeed()
    {
        isRuning = false;
    }
    private void Update()
    {
        if (isRuning)
        {
            speedValue += increaseValue * Time.deltaTime;
            characterAnimator.SetFloat("Speed", speedValue);
        }
    }
}
