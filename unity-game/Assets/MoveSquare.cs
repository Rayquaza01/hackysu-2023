using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSquare : MonoBehaviour {
    public float speed = 0.5f;
    // Rigidbody2D rb;
    public float health = 100f;
    public float damageRate = 10f;
    bool takingDamage = false;
    public Sprite[] states;
    SpriteRenderer sr;
    public GameObject projectile;

    bool autoFire = false;
    public float fireRate = .5f;
    float fireTimer = 0f;

    public float maxFireRate = .1f;
    float manFireTimer = 0f;

    public float multiplierRate = 10f;
    float multiplierTimer = 0f;

    public GameObject ScoreboardDisplay;
    Scoreboard scoreboard;
    public GameObject gameover;

    // Start is called before the first frame update
    void Start() {
        // rb = GetComponent<Rigidbody2D>();

        // rb.AddForce(new Vector2(5, 2.5f), ForceMode2D.Impulse);
        sr = GetComponent<SpriteRenderer>();

        scoreboard = ScoreboardDisplay.GetComponent<Scoreboard>();
    }

    // Update is called once per frame
    void Update() {
        if (health <= 50) {
            sr.sprite = states[1];
        }

        if (health <= 0) {
            sr.sprite = states[2];
            gameover.SetActive(true);

            GameObject[] spawners = GameObject.FindGameObjectsWithTag("spawner");
            for (int i = 0; i < spawners.Length; i++) {
                Destroy(spawners[i]);
            }

            return;
        }

        multiplierTimer += Time.deltaTime;

        if (multiplierTimer > multiplierRate) {
            scoreboard.addMultiplier(1);
            multiplierTimer = 0;
        }

        manFireTimer += Time.deltaTime;

        if (Input.GetMouseButtonDown(0) && manFireTimer >= maxFireRate) {
            Instantiate(projectile, transform.position, transform.rotation);
            autoFire = false;
            manFireTimer = 0;
        }

        if (Input.GetMouseButtonDown(1)) {
            autoFire = !autoFire;
        }

        fireTimer += Time.deltaTime;
        if (fireTimer >= fireRate && autoFire) {
            Instantiate(projectile, transform.position, transform.rotation);
            fireTimer = 0;
        }

        if (Input.GetKey(KeyCode.W)) {
            // rb.AddForce(transform.up, ForceMode2D.Impulse);
            transform.position = transform.position + transform.up * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S)) {
            transform.position = transform.position - transform.up * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D)) {
            transform.position = transform.position + transform.right * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A)) {
            transform.position = transform.position - transform.right * speed * Time.deltaTime;
        }
    }

    void OnCollisionStay2D(Collision2D c) {
        health -= damageRate * Time.deltaTime;
        multiplierTimer = 0;
        scoreboard.setMultiplier(1);
        // Debug.Log(health);
    }
}
