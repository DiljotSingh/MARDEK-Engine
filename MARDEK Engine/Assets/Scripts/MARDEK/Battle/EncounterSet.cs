using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MARDEK.Battle
{
    [CreateAssetMenu(menuName = "MARDEK/Battle/EncounterSet")]
    public class EncounterSet : ScriptableObject
    {
        [SerializeField] List<WeightedEncounter> possibleEncounters = new List<WeightedEncounter>();

        [System.Serializable]
        class WeightedEncounter
        {
            [Range(1, 10)]
            public int encounterWeight = 1;
            public List<EnemyWithLevelRange> encounterEnemies;
        }

        [System.Serializable]
        class EnemyWithLevelRange
        {
            public GameObject enemyPrefab;
            public int minLevel = 0;
            public int maxLevel = 0;
        }

        public List<GameObject> InstantiateEncounter()
        {
            List<GameObject> enemiesInstantiated = new List<GameObject>();

            var chosenEncounter = ChooseEncounter();
            foreach(var enemy in chosenEncounter.encounterEnemies)
            {
                var newEnemy = Instantiate(enemy.enemyPrefab);
                var enemyLevel = Random.Range(enemy.minLevel, enemy.maxLevel + 1);
                // TODO: get enemy character component and set its level
                enemiesInstantiated.Add(newEnemy);
            }
            return enemiesInstantiated;
        }

        WeightedEncounter ChooseEncounter()
        {
            var totalWeight = TotalEncounterWeight();
            var desiredWeight = Random.Range(0, totalWeight);
            var weight = 0;

            // 0 1 2 3 4 5  (desiredWeight)
            // [2] [4] [6]  (weight)

            foreach (var encounter in possibleEncounters)
            {
                weight += encounter.encounterWeight;
                if (desiredWeight < weight)
                    return encounter;
            }
            return null;
        }

        int TotalEncounterWeight()
        {
            int totalWeight = 0;
            foreach (var encounter in possibleEncounters)
                totalWeight += encounter.encounterWeight;
            return totalWeight;
        }
    }
}