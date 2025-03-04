using System.Collections.Generic;
using UnityEngine;

public class PlatformInstance : MonoBehaviour
{
   [SerializeField]
   private List<GameObject> platforms;
   [SerializeField]
   private Transform platformsPosition;
   [SerializeField]
   private float distanceBetweenPlatforms = 2f;

   private int initialPlatforms = 10;

   private float offsetPositionX = 0f;

   private void Start()
   {
       offsetPositionX = 0f;
        InstantiatePlatforms(initialPlatforms);
   }

  public void InstantiatePlatforms(int amount)
  {
        for (int i = 0; i < amount; i++)
        {
            int randomIndex = Random.Range(0, platforms.Count);
            if (offsetPositionX != 0f)
            {
                offsetPositionX += platforms[randomIndex].GetComponent<BoxCollider>().size.x * 0.5f;
            }
            GameObject platform = Instantiate(platforms[randomIndex], new Vector3(offsetPositionX, platformsPosition.position.y, platformsPosition.position.z), Quaternion.identity);
            offsetPositionX += distanceBetweenPlatforms + platform.GetComponent<BoxCollider>().size.x * 0.5f;
            platform.transform.SetParent(transform);
        }

  }
}
