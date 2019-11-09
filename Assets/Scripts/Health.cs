using UnityEngine;

public class Health : MonoBehaviour {
    [SerializeField] private float health = 100;
    [SerializeField] private GameObject deathEffect;
    [SerializeField] private Vector2 offset;
    [SerializeField] private int starValue = 100;

    public void AddToHealth(float amount) {
        health -= amount;
        if(health <= 0) {
            Die();
        }
    }

    private void Die() {
        if(deathEffect) {
            Instantiate(deathEffect, (Vector2)transform.position + offset, Quaternion.identity);
        }

        if(GetComponent<Attacker>()) {
            FindObjectOfType<StarDisplay>().AddStars(starValue);
        }

        GameObject o;
        (o = gameObject).SetActive(false);
        Destroy(o);
    }
}
