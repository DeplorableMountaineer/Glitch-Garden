using System.Collections;
using UnityEngine;

public class SelfDestruct : MonoBehaviour {
    [SerializeField] private float timeTillDestruct = 1.5f;

    // Start is called before the first frame update
    IEnumerator Start() {
        yield return new WaitForSeconds(timeTillDestruct);
        Destroy(gameObject);
    }
}
