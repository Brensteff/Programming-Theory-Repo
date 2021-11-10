/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 0;
    [SerializeField] float turnSpeed = 50f;
    [SerializeField] float speed;
    private float horizontalInput;
    private float forwardInput;
    private Rigidbody playerRb;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        // Moves the car forward based on vertical input
        //transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        playerRb.AddRelativeForce(Vector3.forward * moveSpeed * forwardInput);
        playerRb.AddRelativeForce(Vector3.right * moveSpeed * horizontalInput);
    }


}
*/