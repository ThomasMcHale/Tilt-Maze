using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupRotator : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(15 * Time.deltaTime, 30 * Time.deltaTime, 35 * Time.deltaTime);
	}
}
