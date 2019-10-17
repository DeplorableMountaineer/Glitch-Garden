using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Vector3 offset;

    public void Fire() {
        Instantiate(projectilePrefab, transform.position + offset, Quaternion.identity);
    }
}
