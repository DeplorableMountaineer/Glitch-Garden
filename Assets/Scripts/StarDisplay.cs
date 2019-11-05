using UnityEngine;
using UnityEngine.UI;

public class StarDisplay : MonoBehaviour {
    [SerializeField] private int stars = 100;
    private Text starText;

    void Start() {
        starText = GetComponent<Text>();
        UpdateDisplay();
    }

    private void UpdateDisplay() {
        starText.text = stars.ToString();
    }

    public void AddStars(int howmany) {
        stars += howmany;
        UpdateDisplay();
    }

    public bool SpendStars(int howmany) {
        if(stars >= howmany) {
            stars -= howmany;
            UpdateDisplay();
            return true;
        }
        else {
            return false;
        }
    }
}
