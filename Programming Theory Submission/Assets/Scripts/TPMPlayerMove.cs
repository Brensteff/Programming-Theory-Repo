using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPMPlayerMove : MonoBehaviour
{
	CharacterController Controller;

	[Header ("Basic Variables")]
	public LayerMask groundMask;
	public float Speed;
	public Transform Cam;
	//public float jumpForce = 100.0f;
	//public Vector3 jump;

	private Vector3 velocity;
	private bool isGrounded;
	private Rigidbody playerRb;
	private bool isOnGround = true;

	[Header("Gravity")]
	public float gravity;
	public float maxGravity;
	public float gravityScale = 5;

	private float currentGravity;
	private Vector3 gravityDirection;
	private Vector3 gravityMovement;
	private float gravityModifier;
	private float constantGravity = -30;

	void Start()
	{
		playerRb = GetComponent<Rigidbody>();
		Controller = GetComponent<CharacterController>();
		Physics.gravity *= gravityModifier;
		Cursor.visible = false;
		Screen.lockCursor = true;
		//jump = new Vector3(0.0f, 2.0f, 0.0f);
	}

	void Awake()
    {
		isGrounded = true;
		gravityDirection = Vector3.down; // Gets gravity direction and sets it to down
    }
	void Update()
	{
		CalculateGravity();
		Movement();
		//Jump();
		if (isGrounded == true)
        {
			Debug.Log("Grounded");
        }
		else
        {
			Debug.Log("Not grounded");
        }
		if (Input.GetKeyDown(KeyCode.Escape))
        {
			Cursor.visible = true;
			Screen.lockCursor = false;
        }
		/*if (Input.GetKeyDown(KeyCode.Space))
        {
			Debug.Log("Space pressed");
        }*/
	}
	
	private bool IsGrounded()
    {
		return Controller.isGrounded;
    } //Checks if player is touching ground

	void OnCollisionStay()
    {
		isGrounded = true;
    }

	void OnCollisionLeave()
    {
		isGrounded = false;
    }

	private void CalculateGravity()
    {
		if (isGrounded)
        {
			currentGravity = constantGravity;
        }
		else
        {
			if (currentGravity > maxGravity)
            {
				currentGravity -= gravity * Time.deltaTime;
            }
        }

		gravityMovement = gravityDirection * -currentGravity * Time.deltaTime;
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

	private void Movement()
    {
		float Horizontal = Input.GetAxis("Horizontal") * Speed * Time.deltaTime;
		float Vertical = Input.GetAxis("Vertical") * Speed * Time.deltaTime;

		Vector3 Movement = Cam.transform.right * Horizontal + Cam.transform.forward * Vertical;
		Movement.y = 0f;

		Controller.Move(Movement + gravityMovement);

		if (Movement.magnitude != 0f && isOnGround == true)
		{
			transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * Cam.GetComponent<TPMCameraMove>().sensivity * Time.deltaTime);


			Quaternion CamRotation = Cam.rotation;
			CamRotation.x = 0f;
			CamRotation.z = 0f;

			transform.rotation = Quaternion.Lerp(transform.rotation, CamRotation, 0.1f);
		}
	}

	//Removed from game
	/*private void Jump() 
    {
		if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
		{
			Debug.Log("Space pressed");
			playerRb.AddForce(jump * jumpForce , ForceMode.Impulse);
			isGrounded = false;
		}
    }*/
}
