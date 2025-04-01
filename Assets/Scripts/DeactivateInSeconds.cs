using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class DeactivateInSeconds : MonoBehaviour
{
   [SerializeField]
   private float _secondsToDeactivate = 5f;

   public UnityEvent <GameObject> OnDeactivate;

    private void OnEnable()
    {
        Invoke("DeactivateObject", _secondsToDeactivate);

    }

    private void DeactivateObject()
    {
        gameObject.SetActive(false);
    }
    private void OnDisable()
    {
        OnDeactivate?.Invoke(gameObject);
    }

}
