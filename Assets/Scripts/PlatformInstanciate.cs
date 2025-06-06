using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlatformInstantiate : MonoBehaviour
{
   [SerializeField]
    private List<InstanciateObject> platformsPools;
    [SerializeField]
    private List<InstanciateObject> safePlatformsPools;
    [SerializeField]
    private float distanceBetweenPlatforms = 2f;
    [SerializeField]
    private int initialPlatforms = 10;
    private float offsetPositionX = 0f;

    private int platformsIndex = 0;

    public void Start()
    {
        platformsIndex = 0;
        offsetPositionX = 0;
        InstantiatePlatforms(initialPlatforms);  
    }

    public void InstantiatePlatforms(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            List<InstanciateObject> platformsToUse = platformsIndex < 2 ? safePlatformsPools : platformsPools;
            int randomIndex = Random.Range(0, platformsToUse.Count);
             if (offsetPositionX != 0) 
            {
                offsetPositionX += platformsToUse[randomIndex].ObjectToInstantiate.GetComponent<BoxCollider>().size.x * 0.5f;
            }
            GameObject platform = platformsToUse[randomIndex].CreateInstance();
            offsetPositionX += distanceBetweenPlatforms + platform.GetComponent<BoxCollider>().size.x * 0.5f;
            platform.transform.SetParent(transform);
            platform.transform.localPosition = new Vector3(offsetPositionX, 0,0);
            platformsIndex++;
        }
    }

    public void Restart()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
        Start();
    }
}
