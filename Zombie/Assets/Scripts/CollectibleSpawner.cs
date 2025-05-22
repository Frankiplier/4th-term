using UnityEngine;
using System.Collections.Generic;

public class CollectibleSpawner : MonoBehaviour
{
    [SerializeField] string spawnerId;
    [SerializeField] CollectibleSpawnRegistry spawnRegistry;

    public List<GameObject> collectibles;
    public List<GameObject> locations;

    void Start()
    {
        var data = spawnRegistry.GetOrCreateSpawnerData(spawnerId);

        if (data.isSpawned)
        {
            for (int i = 0; i < Mathf.Min(data.collectibleIndices.Count, data.locationIndices.Count); i++)
            {
                int cIndex = data.collectibleIndices[i];
                int lIndex = data.locationIndices[i];

                if (cIndex < collectibles.Count && lIndex < locations.Count)
                {
                    var collectible = collectibles[cIndex];
                    var location = locations[lIndex];

                    collectible.transform.SetParent(location.transform);
                    collectible.transform.position = location.transform.position;
                }
            }
            return;
        }

        int spawnCount = Mathf.Min(collectibles.Count, locations.Count);

        List<int> cIndices = new List<int>();
        List<int> lIndices = new List<int>();
        for (int i = 0; i < collectibles.Count; i++) cIndices.Add(i);
        for (int i = 0; i < locations.Count; i++) lIndices.Add(i);

        Shuffle(lIndices);

        for (int i = 0; i < spawnCount; i++)
        {
            var collectible = collectibles[cIndices[i]];
            var location = locations[lIndices[i]];

            collectible.transform.position = location.transform.position;
            collectible.transform.SetParent(location.transform);

            data.collectibleIndices.Add(cIndices[i]);
            data.locationIndices.Add(lIndices[i]);
        }

        data.isSpawned = true;
    }

    void Shuffle<T>(List<T> list)
    {
        for (int i = list.Count - 1; i > 0; i--)
        {
            int randIndex = Random.Range(0, i + 1);
            (list[i], list[randIndex]) = (list[randIndex], list[i]);
        }
    }
}