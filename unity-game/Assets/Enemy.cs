using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public string targetTag = "Player";
    public float speed = 5f;
    GameObject target;

    // Start is called before the first frame update
    void Start() {
        target = GameObject.FindWithTag(targetTag);
    }

    // Update is called once per frame
    void Update() {
        Vector2 heading = target.transform.position - transform.position;
        float distance = heading.magnitude;
        Vector2 normalized = (heading / distance) * speed * Time.deltaTime;

        //https://answers.unity.com/questions/1860902/rotate-towards-an-object-in-2d.html
        Quaternion rot = Quaternion.LookRotation(Vector3.forward, heading);
        transform.rotation = Quaternion.Lerp(transform.rotation, rot, Time.deltaTime * speed);

        transform.position = transform.position + new Vector3(normalized.x, normalized.y);
    }
}
