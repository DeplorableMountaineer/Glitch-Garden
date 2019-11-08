using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MeleeAttack : MonoBehaviour {
    private static readonly int IsAttacking = Animator.StringToHash("IsAttacking");
    private Animator animator;
    private Collider2D trigger;
    private HashSet<Collider2D> closeAttackers = new HashSet<Collider2D>();

    [SerializeField] private float damageAmount = 50;


    public void Attack() {
        Collider2D[] colliders = closeAttackers.ToArray();//because closeAttackers can get modified during loop
        foreach(Collider2D a in colliders) {
            Health h = a.gameObject.GetComponent<Health>();
            h.AddToHealth(damageAmount);
        }
    }

    private void Start() {
        animator = GetComponent<Animator>();
        foreach(Collider2D c in GetComponents<Collider2D>()) {
            if(c.isTrigger) {
                trigger = c;
                break;
            }
        }
    }

    private void Update() {
        if(IsAttackerNearby()) {
            animator.SetBool(IsAttacking, true);
        }
        else {
            animator.SetBool(IsAttacking, false);
        }
    }

    private bool IsAttackerNearby() {
        if(closeAttackers.Count <= 0) {
            return false;
        }

        return true;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Attacker a = other.GetComponent<Attacker>();
        if(a) {
            closeAttackers.Add(other);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        Attacker a = other.GetComponent<Attacker>();
        if(a) {
            closeAttackers.Remove(other);
        }
    }
}
