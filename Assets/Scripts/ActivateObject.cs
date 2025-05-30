using UnityEngine;

public class ActivateObject : MonoBehaviour
{
    [SerializeField]
    private GameObject[] objectsToActivate;

    private void OnEnable()
    {
        ActivateAllObjects();
    }

    private void ActivateAllObjects()
    {
        foreach (GameObject obj in objectsToActivate)
        {
            if (obj != null)
            {
                obj.SetActive(true);
            }
        }
    }
}
