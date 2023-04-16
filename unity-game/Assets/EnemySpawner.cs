using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    public float spawnRate = 5;
    public float spawnRateRate = 10;

    public GameObject enemy;

    float timer = 0;
    float srTimer = 0;

    public int type = 0;

    float movementSpeed = 5f;
    int direction = 1;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (type == 0) {
            transform.position = transform.position + transform.right * movementSpeed * Time.deltaTime * direction;
            if (transform.position.x > 11) {
                direction = -1;
            }

            if (transform.position.x < -11) {
                direction = 1;
            }
        }

        if (type == 1) {
            transform.position = transform.position + transform.up * movementSpeed * Time.deltaTime * direction;
            if (transform.position.y > 5) {
                direction = -1;
            }

            if (transform.position.y < -5) {
                direction = 1;
            }
        }

        if (srTimer < spawnRateRate) {
            srTimer += Time.deltaTime;
        } else {
            spawnRate *= 0.8f;
            srTimer = 0;
        }

        if (timer < spawnRate) {
            timer += Time.deltaTime;
        } else {
            if (type == 1) {
                Debug.Log("LR spawning");
            } else {
                Debug.Log("UD Spawning");
            }
            Instantiate(enemy, transform.position, transform.rotation);
            timer = 0;
        }
    }
}
