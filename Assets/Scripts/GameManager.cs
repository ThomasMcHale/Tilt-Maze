using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private GameObject[] balls;
    private int boardSize = 10;
    private GameObject maze;



    void Start ()
    {
        // Initialize Variables
        if (balls == null)
        {
            balls = GameObject.FindGameObjectsWithTag("Ball");
         }
        maze = transform.Find("Maze").gameObject;

        // Randomize the game board
        // First Generate Walls at every other board location, facing in random directions.
        for (int x = boardSize/-2 + 1; x < boardSize/2; x++)
        {
            for (int z = boardSize/-2 + 1; z < boardSize/2; z++)
            {
                if ( (x + z) % 2 == 0 && !(x == 0 && z == 0))
                {
                    GameObject wall = (GameObject) Instantiate(Resources.Load("Prefabs/RotatorWall"));
                    wall.transform.SetParent(maze.transform);
                    wall.transform.position = new Vector3(x, 0, z);
                    wall.transform.Rotate(new Vector3(0, 90 * Random.Range(0, 3), 0));
                }
            }
        }
        // Generate goal
        GameObject goal = (GameObject)Instantiate(Resources.Load("Prefabs/Goal"));
        goal.transform.SetParent(maze.transform);
        Vector3 goalPos = randBoardSquare();
        goal.transform.position = goalPos + new Vector3(0, 0.1f, 0);

        // Generate pickups
        for (int i = 0; i < 6; i++)
        {
            GameObject pickup = (GameObject) Instantiate(Resources.Load("Prefabs/Pickup"));
            Vector3 pickupPos;
            do 
                pickupPos = randBoardSquare(); // Pickups can't be on the goal.
            while (pickupPos.Equals(goalPos));
            pickup.transform.SetParent(maze.transform);
            pickup.transform.position = pickupPos;
        }
    }

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            foreach (GameObject ball in balls)
            {
                ball.GetComponent<Rigidbody>().AddForce(new Vector3(0, 4, 0), ForceMode.Impulse);
            }
        }
    }

    // Generate a Vector3 that corresponds to the center of a square in board.
    private Vector3 randBoardSquare()
    {
        return new Vector3(Random.Range(boardSize / -2 + 1, boardSize / 2 + 1) - 0.5f,
                           0,
                           Random.Range(boardSize / -2 + 1, boardSize / 2 + 1) - 0.5f);
    }
}
