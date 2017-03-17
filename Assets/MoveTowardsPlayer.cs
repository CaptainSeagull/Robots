using UnityEngine;
using System.Collections;

public class MoveTowardsPlayer : MonoBehaviour {
    public GameObject target;
    public float distance;
    public float speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(Vector3.Distance(target.transform.position, transform.position) < distance) {
            //transform.LookAt(target.transform); // TODO(Jonny): Fix

            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed);
        }
	}
}
