using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    public float movementSpeed = 500;
    public float turningSpeed = 120;
    public Rigidbody rb;
    public bool onGround;

    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionStay (Collision collisionInfo) {onGround = true;}
    void OnCollisionExit (Collision collisionInfo) {onGround = false;}

    void FixedUpdate() {
        if ((onGround == true) && (Input.GetButtonDown("Jump"))) {
            rb.velocity = new Vector3(0, 15, 0);
        }
    }

    void Update() {
        float horizontal = Input.GetAxis("Horizontal") * turningSpeed * Time.deltaTime;
        transform.Rotate(0, horizontal, 0);
         
        float vertical = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;
        transform.Translate(0, 0, vertical);

        if(Input.GetKey("j")) {
            transform.Translate(0, 1, 0);
            rb.velocity = new Vector3(0, 0, 0);
        }
    }
}