using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
    [SerializeField] private float health = 100;

    public void AddToHealth(float amount) {
        health -= amount;
        if(health <= 0) {
            Die();
        }
    }

    private void Die() {
        gameObject.SetActive(false);
        Destroy(gameObject);
    }
}

