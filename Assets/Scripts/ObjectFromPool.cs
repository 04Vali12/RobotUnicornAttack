using UnityEngine;
using UnityEngine.Events;

public class ObjectFromPool : MonoBehaviour
{
     public UnityEvent <GameObject> OnDeactivate;

      private void OnDisable()
    {
        OnDeactivate?.Invoke(gameObject);
    }


}
