using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour {
    [SerializeField] private bool spawn = true;
    [SerializeField] private float minSpawnDelay = 1;
    [SerializeField] private float maxSpawnDelay = 5;
    [SerializeField] private Attacker attackerPrefab;

    private float currentMinSpawnDelay;


    IEnumerator Start() {
        yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
        currentMinSpawnDelay = maxSpawnDelay;
        while(spawn) {
            yield return new WaitForSeconds(Random.Range(currentMinSpawnDelay, maxSpawnDelay));
            SpawnAttacker();
            if(currentMinSpawnDelay > minSpawnDelay) {
                currentMinSpawnDelay *= .8f;
                if(currentMinSpawnDelay < minSpawnDelay) {
                    currentMinSpawnDelay = minSpawnDelay;
                }
            }
            else if(maxSpawnDelay > minSpawnDelay) {
                maxSpawnDelay *= .8f;
                if(maxSpawnDelay < minSpawnDelay) {
                    maxSpawnDelay = minSpawnDelay;
                }
            }
        }
    }

    private void SpawnAttacker() {
        Attacker newAttacker = Instantiate<Attacker>(attackerPrefab,
            transform.position, transform.rotation) as Attacker;
        newAttacker.transform.parent = transform;
    }
}
