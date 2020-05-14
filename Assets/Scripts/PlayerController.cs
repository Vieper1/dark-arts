using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerController : MonoBehaviour
{
    [Header("Mode")]
    public bool AirControl;

	[Header("Subobject")]
	public GameObject SpotLight;

    [Header("Config")]
    public float BallMaxRPM = 7;
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

	private Rigidbody rb;
	private Camera mainCamera;
	private Vector3 lastPosition;
    private bool isGrounded = true;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
		mainCamera = Camera.main;
		lastPosition = transform.position;
        rb.maxAngularVelocity = BallMaxRPM;
	}

	void Update()
    {
        isGrounded = FloorCheck();

        // Fake velocity
        FakeVelocity = (transform.position - lastPosition) * Time.deltaTime;
		lastPosition = transform.position;

		
        
        
        // Buttons to ball control
        // MOVE LEFT
		if (Input.GetKey(KeyCode.A)) {
            if (isGrounded)
                rb.AddForceAtPosition(Vector3.left * ForceMultiplier, transform.position + Vector3.up * ForceOffset);
            else
                if (AirControl)
                    rb.AddForceAtPosition(Vector3.left * ForceMultiplier, transform.position + Vector3.up * ForceOffset);
        }

        // MOVE RIGHT
        if (Input.GetKey(KeyCode.D)) {
            if (isGrounded)
                rb.AddForceAtPosition(Vector3.right * ForceMultiplier, transform.position + Vector3.up * ForceOffset);
            else
                if (AirControl)
                rb.AddForceAtPosition(Vector3.right * ForceMultiplier, transform.position + Vector3.up * ForceOffset);
        }

        // JUMP
        if (isGrounded && Input.GetKeyDown(KeyCode.Space)) {
			rb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
		}
        
		// SPOTLIGHT CONTROL
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
		if ((hitLeft || hitRight) && Mathf.Abs(rb.velocity.y) < FloorCheckMinSpeed)
			return true;
		else
			return false;
	}
}
