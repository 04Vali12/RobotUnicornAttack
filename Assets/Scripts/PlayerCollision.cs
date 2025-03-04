using UnityEngine;
using UnityEngine.Events;

public class PlayerCollision : MonoBehaviour
{
   private UnityEvent onPlayerLose;
   private Dash dash;

   private void Start()
   {
        dash = GetComponent<Dash>();
   }

   private void OnCollisionEnter(Collision collision)
   {
       if (collision.gameObject.CompareTag("Obstacle"))
       {
           onPlayerLose.Invoke();
       }
       else 
    {
        onPlayerLose?.Invoke();
       }
   }
}
