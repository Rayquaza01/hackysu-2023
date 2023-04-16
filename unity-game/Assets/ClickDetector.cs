using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickDetector : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        // https://stackoverflow.com/questions/20583653/raycasting-to-find-mouseclick-on-object-in-unity-2d-games
        if (Input.GetMouseButton(0)) {
            Debug.Log("Click");
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null) {
                Destroy(hit.collider.gameObject);
                Debug.Log("Hit!");
            } else {
                Debug.Log("Sploosh!");
            }
        }
    }
}
