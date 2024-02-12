using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class JumpingOverTrigger : MonoBehaviour
{
    public int score = 0;
    private bool canScore = true; // Variable to control the cooldown

    private void OnTriggerEnter(Collider other)
{
    if (other is BoxCollider && other.gameObject.CompareTag("hitbox"))
    {
        if (other.transform.position.y < this.transform.position.y && canScore)
        {
            StartCoroutine(ScoreCooldown());
            score++;
            Debug.Log(gameObject.name + "'s score: " + score);

            //if (score >= 5)
              //  {
                    // Load the next scene
                   // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
               // }

        }
    }
}

    IEnumerator ScoreCooldown()
    {
        canScore = false; // Start cooldown
        yield return new WaitForSeconds(1); // Wait for 1 seconds
        canScore = true; // End cooldown
    }
}