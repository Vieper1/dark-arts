using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerController : MonoBehaviour
{
	[Header("Subobject")]
	public GameObject SpotLight;

	[Header("Config")]
	public float ForceMultiplier;
	public float ForceOffset;
	public float LerpSpeed;
	public float JumpForce;
	public float FloorCheckThreshold;
	public float FloorCheckSeparation;
	public float FloorCheckMinSpeed;
	public float CameraVerticalOffset;

	[Header("Player")]
	public Vector3 FakeVelocity;

	private Rigidbody rigidbody;
	private Camera mainCamera;
	private Vector3 lastPosition;

	void Start()
	{
		rigidbody = GetComponent<Rigidbody>();
		mainCamera = Camera.main;
		lastPosition = transform.position;
	}

	void Update()
    {
		// Fake velocity
		FakeVelocity = (transform.position - lastPosition) * Time.deltaTime;
		lastPosition = transform.position;

		// Buttons to ball control
		if (Input.GetKey(KeyCode.A)) {
			rigidbody.AddForceAtPosition(Vector3.left * ForceMultiplier, Vector3.up * ForceOffset);
			rigidbody.AddTorque(Vector3.forward * 100.0f * ForceMultiplier, ForceMode.Impulse);
		}

		if (Input.GetKey(KeyCode.D)) {
			rigidbody.AddForceAtPosition(Vector3.right * ForceMultiplier, Vector3.up * ForceOffset);
			rigidbody.AddTorque(Vector3.back * 100.0f * ForceMultiplier, ForceMode.Impulse);
		}

		FloorCheck();
		if (FloorCheck() && Input.GetKeyDown(KeyCode.Space)) {
			rigidbody.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
		}

		// Mouse Position to SpotLight Direction
		Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
		diff.z = 0;
		diff.Normalize();

		Quaternion quat = Quaternion.LookRotation(diff, Vector3.up);
		SpotLight.transform.rotation = quat;
	}

	void LateUpdate()
	{
		// Camera Position Update
		Vector3 targetPosition = transform.position;
		targetPosition.z = mainCamera.transform.position.z;
		mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, targetPosition + Vector3.up * CameraVerticalOffset, LerpSpeed * Time.deltaTime);
		//mainCamera.transform.position = targetPosition;
	}



	// Custom
	bool FloorCheck()
	{
		Debug.DrawLine(transform.position, transform.position + Vector3.down * FloorCheckThreshold + Vector3.left * FloorCheckSeparation);
		Debug.DrawLine(transform.position, transform.position + Vector3.down * FloorCheckThreshold + Vector3.right * FloorCheckSeparation);

		bool hitLeft = Physics.Linecast(transform.position, transform.position + Vector3.down * FloorCheckThreshold + Vector3.left * FloorCheckSeparation);
		bool hitRight = Physics.Linecast(transform.position, transform.position + Vector3.down * FloorCheckThreshold + Vector3.right * FloorCheckSeparation);
		if ((hitLeft || hitRight) && Mathf.Abs(rigidbody.velocity.y) < FloorCheckMinSpeed)
			return true;
		else
			return false;
	}
}
