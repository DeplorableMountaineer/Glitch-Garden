using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {
    [SerializeField] private float waitTime = 3;
    [SerializeField] private string levelToLoad = "Start Screen";

    // Start is called before the first frame update
    IEnumerator Start() {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(levelToLoad);
    }
}
