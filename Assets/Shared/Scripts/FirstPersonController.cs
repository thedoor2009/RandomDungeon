using UnityEngine;
using System.Collections;

public class FirstPersonController : MonoBehaviour {

	public float movementSpeed = 10.1f;
	public float mouseSensitivity = 3.0f;
	public float jumpSpeed  = 5.0f;
	public float upDownRange = 60.0f;
	
	float verticalRotation = 0;
	float rotLeftRight = 0;
	float verticalVelocity = 0;
	
	CharacterController characterController;
	
	#region Hook
	void Start () {
		Screen.lockCursor = true;
		characterController = GetComponent<CharacterController>();
		if(characterController == null) Debug.LogError("No characterController Attached.");
	}
	#endregion

	void Update () {
		
		PlayerRotate();
		PlayerMove();
	}
		
	#region Behavior Functions
	private void PlayerRotate()
	{		
		rotLeftRight = Input.GetAxis("Mouse X") * mouseSensitivity;
		transform.Rotate(0,rotLeftRight,0);
		
		
		verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;
		verticalRotation = Mathf.Clamp(verticalRotation,-upDownRange,upDownRange);
		Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation,0,0);
	}
	
	private void PlayerMove()
	{
		float forwardSpeed = Input.GetAxis("Vertical") * movementSpeed;
		float sideSpeed = Input.GetAxis("Horizontal") * movementSpeed;
		if(Input.GetKey(KeyCode.LeftShift))
		{
			forwardSpeed = Input.GetAxis("Vertical") * movementSpeed *2.4f;
			sideSpeed = Input.GetAxis("Horizontal") * movementSpeed *2.4f;
		}
		
		verticalVelocity += Physics.gravity.y * Time.deltaTime;
	
		if(characterController.isGrounded && Input.GetButtonDown("Jump"))
		{
			verticalVelocity = 2.0f;
		}
		Vector3 speed = new Vector3(sideSpeed,verticalVelocity,forwardSpeed);
		speed = transform.rotation * speed;
		
		characterController.Move(speed * Time.deltaTime);
	}
	#endregion
}
