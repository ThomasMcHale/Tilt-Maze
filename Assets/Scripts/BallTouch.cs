using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BallTouch : MonoBehaviour {

    public Text scoreText;
    public Text winText;
    public int pickupsRequired;

    private Rigidbody rb;
    private bool won;
    private int score;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        won = false;
        score = 0;
        updateScoreText();
        winText.enabled = false;
    }

    void FixedUpdate()
    {
        if (transform.position.y < -10) {
            scoreText.text = "Sorry. You lose!";
        }
    }
	
	void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Pickup"))
        {
            Destroy(other.gameObject);
            score++;
            if (score >= pickupsRequired)
            {
                scoreText.text = "Done! Go to the goal!";
            } else
            {
                updateScoreText();
            }
        }
        if (other.gameObject.CompareTag("Goal") && score >= 2 && won == false )
        {
            won = true;
            rb.useGravity = false;
            rb.AddForce(0, 500, 0);
            scoreText.enabled = false;
            winText.enabled = true;
        }
	}

    private void updateScoreText()
    {
        scoreText.text = "Pick-ups Remaining: " + (pickupsRequired - score).ToString();
    }
}
