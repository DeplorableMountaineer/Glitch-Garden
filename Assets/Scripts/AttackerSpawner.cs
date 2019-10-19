using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour {
    [SerializeField] private bool spawn = true;
    [SerializeField] private float minSpawnDelay = 1;
    [SerializeField] private float maxSpawnDelay = 5;
    [SerializeField] private Attacker attackerPrefab;

    IEnumerator Start() {
        while(spawn) {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnAttacker();
        }
    }

    private void SpawnAttacker() {
        Instantiate(attackerPrefab, transform.position, transform.rotation);
    }
}
