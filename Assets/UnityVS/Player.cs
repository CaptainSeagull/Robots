using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    public float movementSpeed = 500;
    public float turningSpeed = 120;
    public GameObject back;
    public GameObject text;
    public GameObject line;
    public Rigidbody rb;
    public bool onGround;
    Vector3 checkpoint;

    float timer = 0;

    void Start() {
        rb = GetComponent<Rigidbody>();

        back.SetActive(false);
        text.SetActive(false);
        line.SetActive(false);
    }

    void OnCollisionStay (Collision collisionInfo) {onGround = true;}
    void OnCollisionExit (Collision collisionInfo) {onGround = false;}

    void FixedUpdate() {
        if ((onGround == true) && (Input.GetButtonDown("Jump"))) {
            rb.velocity = new Vector3(0, 15, 0);
        }
    }

     void OnTriggerEnter(Collider collider) {
        if (collider.name.Equals("Trigger"))
        { 
            back.SetActive(true);
            text.SetActive(true);
            line.SetActive(true);
            timer = 120;
        } else if (collider.name.Equals("BoundingBox")) {
            transform.position = checkpoint;      
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
            
        if (onGround) {
            checkpoint = transform.position;
        }
        
        if(timer > 0) {
            timer -= 1;
        } else {
            back.SetActive(false);
            text.SetActive(false);
            line.SetActive(false);
        }
    }
}