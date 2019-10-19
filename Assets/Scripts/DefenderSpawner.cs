using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour {
    [SerializeField] private GameObject defender;

    private void OnMouseDown() {
        Vector2 position = GetSquareClicked();
        SpawnDefender(position);
    }

    private Vector2 GetSquareClicked() {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        return worldPos;
    }

    private void SpawnDefender(Vector2 position) {
        GameObject newDefender = Instantiate(defender, position, Quaternion.identity) as GameObject;
    }
}
