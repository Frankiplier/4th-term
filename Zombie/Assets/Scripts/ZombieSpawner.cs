using System.Collections;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public DialogueTrigger trigger;

    [System.Serializable]
    public class ZombieAnimationSet
    {
        public string form1StateName;
        public string form2StateName;
    }

    public GameObject zombiePrefab;
    public ZombieAnimationSet[] zombieAnimationSets;

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

            int animIndex = Random.Range(0, zombieAnimationSets.Length);

            GameObject zombie = Instantiate(zombiePrefab, spawnPos, Quaternion.identity);
            Zombie zombieScript = zombie.GetComponent<Zombie>();
            zombieScript.SetAnimationSet(zombieAnimationSets[animIndex]);

            trigger.TriggerDialogue();
        }
    }
}