using UnityEngine;

public class Defender : MonoBehaviour {
    [SerializeField] private int starCost = 100;
    [SerializeField] private int starAmount = 10;
    [SerializeField] private Transform starSpawnPoint;
    [SerializeField] private GameObject starPrefab;

    private StarDisplay starDisplay;

    private void Start() {
        starDisplay = FindObjectOfType<StarDisplay>();
        if(!starDisplay.SpendStars(starCost)) {
            Destroy(gameObject);
        }
    }

    public void AddStars() {
        starDisplay.AddStars(starAmount);
        Instantiate(starPrefab, starSpawnPoint);
    }
}
