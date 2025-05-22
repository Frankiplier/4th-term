using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "Scriptable Objects/Collectible Spawn Registry")]
public class CollectibleSpawnRegistry : ScriptableObject
{
    [System.Serializable]
    public class SpawnerData
    {
        public string spawnerId;
        public bool isSpawned;
        public List<int> collectibleIndices = new List<int>();
        public List<int> locationIndices = new List<int>();
    }

    public List<SpawnerData> spawners = new List<SpawnerData>();

    public SpawnerData GetOrCreateSpawnerData(string spawnerId)
    {
        var existing = spawners.Find(s => s.spawnerId == spawnerId);
        if (existing != null) return existing;

        var newData = new SpawnerData { spawnerId = spawnerId };
        spawners.Add(newData);
        return newData;
    }

    public void ClearAll()
    {
        spawners.Clear();
    }
}