using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {
    public GameObject bullet;
    public GameObject target;
    public float distance;
    int shooting_timer = 0;
    float tx, ty, tz;

	// Use this for initialization
	void Start () {}
	
	// Update is called once per frame
	void Update () {
        --shooting_timer;
        if (shooting_timer > 0) {
            Vector3 v = new Vector3(tx, ty, tz);
            bullet.transform.position = Vector3.MoveTowards(bullet.transform.position, v, 1.5f);
        } else {
            bullet.transform.position = transform.position;
	        if(Vector3.Distance(target.transform.position, transform.position) < distance) {
                tx = target.transform.position.x;
                ty = target.transform.position.y;
                tz = target.transform.position.z;
                shooting_timer = 50;
            }
        }
	}
}
