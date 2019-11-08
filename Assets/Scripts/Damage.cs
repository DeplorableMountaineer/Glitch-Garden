using UnityEngine;

public class Damage : MonoBehaviour {
    [SerializeField] private float amount = 50;
    [SerializeField] private bool isDefenderProjectile = true;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.isTrigger) {
            return;
        }
        Health h = other.gameObject.GetComponent<Health>();
        if(isDefenderProjectile) {
            Attacker attacker = other.gameObject.GetComponent<Attacker>();
            if(h && attacker) {
                ApplyDamage(h);
            }
        }
        else {
            Defender defender = other.gameObject.GetComponent<Defender>();
            if(h && defender) {
                ApplyDamage(h);
            }
        }
    }

    private void ApplyDamage(Health h) {
        h.AddToHealth(amount);
        gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
