using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardController : MonoBehaviour {


    public float tiltSensitivity;
    private float maxTilt;

	// Use this for initialization
	void Start () {
        maxTilt = 20.0f;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 angles = normalize(transform.rotation.eulerAngles);

        float xInc = Time.deltaTime * tiltSensitivity * Input.GetAxis("Vertical");
        float zInc = Time.deltaTime * tiltSensitivity * -1 * Input.GetAxis("Horizontal");

        if (Mathf.Abs(angles.x + xInc) >= 180 - maxTilt )
        {
            transform.Rotate(xInc, 0, 0);
        }

        if (Mathf.Abs(angles.z + zInc) >= 180 - maxTilt)
        {
            transform.Rotate(0, 0, zInc);
        }

    }

    private Vector3 normalize(Vector3 angles)
    {
        return new Vector3(angles.x - 180, angles.y - 180, angles.z - 180);
    }
}
