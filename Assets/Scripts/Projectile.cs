using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour {
    [SerializeField] private Vector2 velocity = Vector2.right;
    [SerializeField] private float rotationSpeed = -Mathf.PI/2;

    void Start() {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.AddForce(velocity, ForceMode2D.Impulse);
        rb.AddTorque(rotationSpeed, ForceMode2D.Impulse);
    }
}
