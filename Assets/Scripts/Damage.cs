using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {
    [SerializeField] private float amount = 50;

    private void OnTriggerEnter2D(Collider2D other) {
        Health h = other.gameObject.GetComponent<Health>();
        Attacker attacker = other.gameObject.GetComponent<Attacker>();
        if(h && attacker) {
            ApplyDamage(h);
        }
    }

    private void ApplyDamage(Health h) {
        h.AddToHealth(amount);
        gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
