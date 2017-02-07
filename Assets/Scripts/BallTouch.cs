using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTouch : MonoBehaviour {

    private Rigidbody rb;
    private bool won;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        won = false;
    }
	
	void OnTriggerEnter(Collider other) {
        if (other.gameObject.name == "Goal" && won == false)
        {
            won = true;
            rb.useGravity = false;
            rb.AddForce(0, 500, 0);
        }
		
	}
}
