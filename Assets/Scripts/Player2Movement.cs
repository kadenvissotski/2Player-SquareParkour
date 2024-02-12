using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2 : MonoBehaviour
{
    public float speed = 10.0f; // You can adjust the speed to your liking
    public float jumpForce = 2.0f; // You can adjust the jump force to your liking
    private bool isJumping = false;
    public float rotationSpeed = 100.0f;
    public float boostedSpeed = 20f;


    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            switch (true)
            {
            case var _ when Input.GetKey(KeyCode.I):
                transform.Translate(new Vector3(0, 0, 1) * speed * Time.deltaTime);
                break;
            case var _ when Input.GetKey(KeyCode.J):
                transform.Rotate(new Vector3(0, -1, 0) * rotationSpeed * Time.deltaTime);
                break;
            case var _ when Input.GetKey(KeyCode.L):
                transform.Rotate(new Vector3(0, 1, 0) * rotationSpeed * Time.deltaTime);
                break;
            case var _ when Input.GetKey(KeyCode.K) && !isJumping:
                GetComponent<Rigidbody>().AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
                isJumping = true;
                break;
            }
        }
    }

    // Detect collision with the ground
    void OnCollisionEnter(Collision collision)
    {
        isJumping = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other is SphereCollider)
        {
            StartCoroutine(SpeedBoost());
            Destroy(other.gameObject); // Destroy the game object
        }
    }

    IEnumerator SpeedBoost()
    {
        speed = boostedSpeed; // Increase speed
        yield return new WaitForSeconds(5); // Wait for 5 seconds
        speed = 10f; // Reset speed
    }
}