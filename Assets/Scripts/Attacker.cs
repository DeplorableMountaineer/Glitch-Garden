using System;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour {
    private float currentSpeed = 0;
    private float normalSpeed = 0;
    private HashSet<Collider2D> touching = new HashSet<Collider2D>();

    void Update() {
        transform.Translate(Vector2.left*currentSpeed*Time.deltaTime);
    }

    public void SetMovementSpeed(float speed) {
        currentSpeed = speed;
        if(normalSpeed < 0.001f) {
            normalSpeed = speed;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.GetComponent<Defender>()) {
            touching.Add(other.collider);
            SetMovementSpeed(0);
        }
    }

    private void OnCollisionExit2D(Collision2D other) {
        if(touching.Contains(other.collider)) {
            touching.Remove(other.collider);
        }

        if(touching.Count == 0) {
            SetMovementSpeed(normalSpeed);
        }
    }
}
