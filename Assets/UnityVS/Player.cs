using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    public float movementSpeed = 500;
    public float turningSpeed = 120;
    public GameObject back;
    public GameObject text;
    public GameObject line;
    public GameObject fire;
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
        if (onGround == true) {
            if (Input.GetButtonDown("Jump")) {
                rb.AddForce(new Vector3(0, 150, 0), ForceMode.Impulse);
            }
        }
    }

     void OnTriggerEnter(Collider collider) {
        if (collider.name.Equals("end")) {
            Application.LoadLevel("end");
        } else if (collider.name.Equals("Trigger")) { 
            back.SetActive(true);
            text.SetActive(true);
            line.SetActive(true);
            timer = 120;
        } else if (collider.name.Equals("BoundingBox")) {
            if((!Input.GetKey("k")) && ((onGround) || (rb.velocity.y > 0))) {
                transform.position = checkpoint;
            } else {
                collider.gameObject.transform.parent.position = new Vector3(100, 100, 100);
            }
        } else if (collider.name.Equals("Bullet") || collider.name.Equals("Lava")) {
            transform.position = checkpoint;
        } else {
            for(int i = 0; (i < 100); ++i) {
                if(collider.name.Equals("Checkpoint (" + i + ")")) {
                    checkpoint = transform.position;
                    break;
                }
            }
        }
    }

    void Update() {
        if(onGround == true)
        {
            fire.transform.position = new Vector3(1000, 1000, 1000);
        }
        else
        {
            fire.transform.position = transform.position;
        }

        float horizontal = Input.GetAxis("Horizontal") * turningSpeed * Time.deltaTime;
        transform.Rotate(0, horizontal, 0);
         
        float vertical = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;
        transform.Translate(0, 0, vertical);

        if(Input.GetKey("j")) {
            transform.Translate(0, 1, 0);
            rb.velocity = new Vector3(0, 0, 0);
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