using System.Collections;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    [System.Serializable]
    public class ZombieSpriteSet
    {
        public Sprite form1, form2;
    }

    public GameObject zombiePrefab;
    public ZombieSpriteSet[] zombieSpriteSets;

    public float spawnIntervalMin, spawnIntervalMax;

    public float minX, maxX, spawnY;

    void Start()
    {
        StartCoroutine(SpawnZombies());
    }

    IEnumerator SpawnZombies()
    {
        while (true)
        {
            float waitTime = Random.Range(spawnIntervalMin, spawnIntervalMax);
            yield return new WaitForSeconds(waitTime);

            Vector2 spawnPos = new Vector2(Random.Range(minX, maxX), spawnY);
            int spriteIndex = Random.Range(0, zombieSpriteSets.Length);

            GameObject zombie = Instantiate(zombiePrefab, spawnPos, Quaternion.identity);
            Zombie zombieScript = zombie.GetComponent<Zombie>();
            zombieScript.SetSpriteSet(zombieSpriteSets[spriteIndex]);
        }
    }
}