using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PickupKey : MonoBehaviour
{
    [Header("Config")]
    public string NextLevelName;

	private float time = 0f;
	private Vector3 InitialPosition;
	private float FloatSpeed = 8.0f;
	private float FloatAmplitude = 0.25f;

	private void Start()
	{
		InitialPosition = transform.position;
	}

	void Update()
	{
		time += Time.deltaTime;
		if (time > 2 * Mathf.PI)
			time -= 2 * Mathf.PI;

		transform.position = new Vector3(InitialPosition.x, InitialPosition.y + Mathf.Sin(time * FloatSpeed) * FloatAmplitude , InitialPosition.z);
	}


	// Pickup
	private void OnTriggerEnter(Collider other)
	{
		string[] sceneNameSplit = SceneManager.GetActiveScene().name.Split('-');
		SceneManager.LoadScene(NextLevelName.Equals("") ? sceneNameSplit[0] + "-" + (int.Parse(sceneNameSplit[1]) + 1) : NextLevelName);
	}
}