using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderButton : MonoBehaviour {
    [SerializeField] GameObject defenderPrefab;
    [SerializeField] private Color selectedColor = Color.white;
    [SerializeField] private Color deselectedColor = new Color(.8f, .8f, .8f, .8f);

    private void OnMouseDown() {
        GetComponent<SpriteRenderer>().color = selectedColor;
        FindObjectOfType<DefenderSpawner>().SetSelectedDefender(defenderPrefab);
        foreach(DefenderButton b in FindObjectsOfType<DefenderButton>()) {
            if(b != this) {
                b.GetComponent<SpriteRenderer>().color = deselectedColor;
            }
        }
    }
}
