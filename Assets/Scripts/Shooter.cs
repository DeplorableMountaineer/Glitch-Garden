using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Vector3 offset;

    private readonly List<AttackerSpawner> myLaneSpawners = new List<AttackerSpawner>();
    private static readonly int IsAttacking = Animator.StringToHash("IsAttacking");
    private Animator animator;

    public void Fire() {
        Instantiate(projectilePrefab, transform.position + offset, Quaternion.identity);
    }

    private void Start() {
        animator = GetComponent<Animator>();
        SetLaneSpawner();
    }

    private void SetLaneSpawner() {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();
        foreach(AttackerSpawner spawner in spawners) {
            if(Mathf.Abs(spawner.transform.position.y - transform.position.y) <= 0.5f) {
                myLaneSpawners.Add(spawner);
            }
        }
    }

    private void Update() {
        if(IsAttackerInLane()) {
            animator.SetBool(IsAttacking, true);
        }
        else {
            animator.SetBool(IsAttacking, false);
        }
    }

    private bool IsAttackerInLane() {
        foreach(AttackerSpawner spawner in myLaneSpawners) {
            if(spawner.transform.childCount > 0) {
                return true;
            }
        }

        return false;
    }
}
