using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // For Text component
using UnityEngine.SceneManagement; // For SceneManager

public class Score2 : MonoBehaviour
{
    public Text scoreTextPlayer2; // Reference to the Text component
    private int currentScore = 0; // Variable to keep track of the current score

    // Start is called before the first frame update
    void Start()
    {
        scoreTextPlayer2.text = "Player 2: " + currentScore.ToString(); // Initialize the text
    }

    // Method to update the score
    public void UpdateScore(int newScore)
    {
        currentScore += newScore; // Increment the current score
        scoreTextPlayer2.text = "Player 2: " + currentScore.ToString(); // Update the score text

        if (currentScore >= 4)
    {
        // Load the next scene in the hierarchy
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }
    }

    // Method to handle player colliding with a powerup
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<SphereCollider>() != null)
        {
           UpdateScore(1); // Increase the score by 1
        }
    }
}