using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    private float groundHeight;
    void Start() {
        groundHeight = transform.position.y;
    }

    void Update(){

        if (Input.anyKey && !StaticValues.gameIsPaused && !StaticValues.gameIsEnded && !StaticValues.gameIsRunning) {
            StaticValues.gameIsRunning = true;
        }

        if (StaticValues.gameIsRunning) {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
                transform.Translate(transform.right * (-1 * StaticValues.sensitivity * Time.deltaTime));
            }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
                transform.Translate(transform.right * (StaticValues.sensitivity * Time.deltaTime));
            }
            if (Input.GetKey(KeyCode.Space)) {
                if (transform.position.y <= 0.5f) {
                    GetComponent<Rigidbody>().AddForce(new Vector3(0, StaticValues.jumpForce, 0));
                }
            }
            transform.Translate(transform.forward * (StaticValues.speed * Time.deltaTime));
        }
    }
}
