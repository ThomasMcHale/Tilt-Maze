using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallRotator : MonoBehaviour {

    private bool turning;
    private float curDegree;
    private float rotAmnt;
    private int direction;

    // Initialize our rotation state variables.
	void Start () {
        turning = false;
        curDegree = 0.0f;
        rotAmnt = 0.0f;
        direction = 1;
	}
	
	void Update () {
        if (turning)
        {
            // Calculate how much we need to rotate in this frame, adjusting so that we don't overrotate.
            rotAmnt = 90 * Time.deltaTime;
            if (curDegree + rotAmnt > 90)
            {
                rotAmnt = 90 - curDegree;
            }

            // Rotate and check if we've arrived at our desired angle.
            transform.Rotate(0, rotAmnt * direction, 0);
            curDegree += rotAmnt;
            if (curDegree >= 90)
            {
                turning = false;
            }
        } else if (Random.Range(0.0f, 1.0f) < Time.deltaTime / 10) //  begin rotating ~ every 10 seconds
        {
            turning = true;
            curDegree = 0.0f;
            rotAmnt = 0.0f;
            direction = (Random.Range(0, 2) * 2) - 1; // Generate -1 or +1
        }

	}
}
