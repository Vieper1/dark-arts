using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBlock : MonoBehaviour
{
	public Material ActivatedMaterial;

	void OnCollisionEnter(Collision collision)
	{
		if (collision.transform.GetComponent<PlayerController>() && collision.transform.position.y > transform.position.y)
		{
			GetComponent<MeshRenderer>().material = ActivatedMaterial;
		}
	}
}
