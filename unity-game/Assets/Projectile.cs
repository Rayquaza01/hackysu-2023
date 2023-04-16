using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
    public float speed = 5;
    Vector2 direction;
    public int pierce = 2;
    public int pierceCount = 0;

    // Start is called before the first frame update
    void Start() {
        Destroy(this.gameObject, 5);

        Vector2 heading = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        direction = (heading / heading.magnitude) * speed;

        //https://answers.unity.com/questions/1860902/rotate-towards-an-object-in-2d.html
        Quaternion rot = Quaternion.LookRotation(Vector3.forward, heading);
        transform.rotation = Quaternion.Lerp(transform.rotation, rot, Time.deltaTime * speed);
    }

    // Update is called once per frame
    void Update() {
        transform.position = transform.position + new Vector3(direction.x, direction.y) * Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D c) {
        Debug.Log("Collided");
        if (c.gameObject.CompareTag("enemy")) {
            GameObject.FindGameObjectWithTag("score").GetComponent<Scoreboard>().addScore(1);

            Destroy(c.gameObject);

            pierceCount++;

            if (pierceCount >= pierce) {
                Destroy(this.gameObject);
            }
        }
    }
}
