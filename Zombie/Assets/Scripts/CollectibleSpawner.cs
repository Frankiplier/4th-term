using UnityEngine;
using System.Collections.Generic;

public class CollectibleSpawner : MonoBehaviour
{
    public List<GameObject> collectibles;
    public List<GameObject> locations;

    void Start()
    {
        int spawnCount = Mathf.Min(collectibles.Count, locations.Count);

        List<GameObject> collectiblesPool = new List<GameObject>(collectibles);
        List<GameObject> locationsPool = new List<GameObject>(locations);

        Shuffle(locationsPool);

        for (int i = 0; i < spawnCount; i++)
        {
            GameObject spawned = Instantiate(
                collectiblesPool[i],
                locationsPool[i].transform.position,
                Quaternion.identity,
                locationsPool[i].transform
            );
        }
    }

    void Shuffle<T>(List<T> list)
    {
        for (int i = list.Count - 1; i > 0; i--)
        {
            int randIndex = Random.Range(0, i + 1);
            T temp = list[i];
            list[i] = list[randIndex];
            list[randIndex] = temp;
        }
    }
}