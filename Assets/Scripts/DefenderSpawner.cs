using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour {
    private GameObject _defenderPrefab;

    private void OnMouseDown() {
        Vector2 position = GetSquareClicked();
        foreach(Defender d in FindObjectsOfType<Defender>()) {
            if(Vector2.Distance(d.transform.position, position) < 0.5f) {
                return;
            }
        }
        SpawnDefender(position);
    }

    public void SetSelectedDefender(GameObject defenderPrefab) {
        _defenderPrefab = defenderPrefab;
    }

    private Vector2 GetSquareClicked() {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        Vector2 gridPos = SnapToGrid(worldPos);
        return gridPos;
    }

    private Vector2 SnapToGrid(Vector2 rawWorldPos) {
        float newX = Mathf.RoundToInt(rawWorldPos.x);
        float newY = Mathf.RoundToInt(rawWorldPos.y);
        return new Vector2(newX, newY);
    }

    private void SpawnDefender(Vector2 position) {
        if(_defenderPrefab) {
            GameObject newDefender = Instantiate(_defenderPrefab, position, Quaternion.identity) as GameObject;
        }
    }
}
