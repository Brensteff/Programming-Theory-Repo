using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPMPlayerMove : MonoBehaviour
{
	CharacterController Controller;

	private Rigidbody playerRb;

	public float Speed;
	public int gravity = 1;
	public Transform Cam;
	public float gravityModifier;

	bool isOnGround = true;
	void Start()
	{
		playerRb = GetComponent<Rigidbody>();
		Controller = GetComponent<CharacterController>();
		Physics.gravity *= gravityModifier;
	}

	void Update()
	{
		float Horizontal = Input.GetAxis("Horizontal") * Speed * Time.deltaTime;
		float Vertical = Input.GetAxis("Vertical") * Speed * Time.deltaTime;

		Vector3 Movement = Cam.transform.right * Horizontal + Cam.transform.forward * Vertical;
		Movement.y = 0f;

		Controller.Move(Movement);

		if (Movement.magnitude != 0f && isOnGround == true)
		{
			transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * Cam.GetComponent<TPMCameraMove>().sensivity * Time.deltaTime);


			Quaternion CamRotation = Cam.rotation;
			CamRotation.x = 0f;
			CamRotation.z = 0f;

			transform.rotation = Quaternion.Lerp(transform.rotation, CamRotation, 0.1f);
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag("Ground"))
		{
			isOnGround = true;
			Debug.Log("You are on ground");
		}
        else
        {
			isOnGround = false;
        }
	}
}
