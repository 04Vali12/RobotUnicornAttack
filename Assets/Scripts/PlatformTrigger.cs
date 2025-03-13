using UnityEngine;
using UnityEngine.Events;

public class PlatformTrigger : MonoBehaviour
{
   [SerializeField]
   public UnityEvent onPLatformTriggered;

   public void OnTriggerEnter(Collider other)
   {
       if (other.gameObject.CompareTag("DeadZone"))
       {
           Desrtroy(other.gameObject);
           onPLatformTriggered?.Invoke();
       }
   }
}
