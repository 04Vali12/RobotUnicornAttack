using System.Collections.Generic;
using UnityEngine;

public class InstantiateObject : MonoBehaviour
{
    [SerializeField] 
    public GameObject _ObjectToInstantiate;
    [SerializeField]
    private Stack<GameObject> _objectPool = new Stack<GameObject>();

    

    public void instantiateOnjectAtPosition(Transform asset)
    {
        GameObject obj = CreateInstance();
        obj.transform.position = asset.position;
    }

    public GameObject CreateInstance()
    {
        GameObject obj;
        if (_objectPool.Count > 0)
        {
            obj = _objectPool.Pop();
            obj.SetActive(true);
        }
        else
        {
            obj = Instantiate(_ObjectToInstantiate, transform.position, Quaternion.identity);
            obj.GetComponent<ObjectFromPool>().OnDeactivate.AddListener(OnObjectDeactivated);
        }
        return obj;
    }
    public void OnObjectDeactivated(GameObject obj)
    {
        _objectPool.Push(obj);
    }
}
