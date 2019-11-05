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
        while(spawn) {
            currentMinSpawnDelay = maxSpawnDelay;
            yield return new WaitForSeconds(Random.Range(currentMinSpawnDelay, maxSpawnDelay));
            SpawnAttacker();
            if(currentMinSpawnDelay > minSpawnDelay) {
                currentMinSpawnDelay *= .95f;
                if(currentMinSpawnDelay < minSpawnDelay) {
                    currentMinSpawnDelay = minSpawnDelay;
                }
            }
            else if(maxSpawnDelay > minSpawnDelay) {
                maxSpawnDelay *= .95f;
                if(maxSpawnDelay < minSpawnDelay) {
                    maxSpawnDelay = minSpawnDelay;
                }
            }
        }
    }

    private void SpawnAttacker() {
        Instantiate(attackerPrefab, transform.position, transform.rotation);
    }
}
