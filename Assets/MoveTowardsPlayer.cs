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
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed);

            Vector3 targetDir = target.transform.position - transform.position;    
            float step = 1 * Time.deltaTime;
            Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);
            Debug.DrawRay(transform.position, newDir, Color.red);
            transform.rotation = Quaternion.LookRotation(newDir);
        }
	}
}
