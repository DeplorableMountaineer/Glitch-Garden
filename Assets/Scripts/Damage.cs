using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {
    [SerializeField] private float amount = 50;

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Trigger");
        Health h = other.gameObject.GetComponent<Health>();
        if(h && other.gameObject.GetComponent<Attacker>()) {
            h.AddToHealth(amount);
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
