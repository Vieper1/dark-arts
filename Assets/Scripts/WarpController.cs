using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpController : MonoBehaviour
{
	[Header("References")]
	public GameObject SpotLightRef;

	[Header("Config")]
	public int NumberOfTraces = 2;
	public float TraceLength;

	private Light spotLight;
	private float range;
	private float angle;
	private List<GameObject> litSet = new List<GameObject>();

    void Start()
    {
		spotLight = SpotLightRef.GetComponent<Light>();
		range = spotLight.range;
		angle = spotLight.spotAngle;
    }

    void Update()
    {
		//Debug.DrawLine(transform.position, transform.position + spotLight.transform.forward * TraceLength);
		//Debug.DrawLine(transform.position, transform.position + Quaternion.AngleAxis(angle / 2f, Vector3.forward) * spotLight.transform.forward * TraceLength);
		//Debug.DrawLine(transform.position, transform.position + Quaternion.AngleAxis(-angle / 2f, Vector3.forward) * spotLight.transform.forward * TraceLength);
		TraceConeCollision();
    }












	// Trace
	void TraceConeCollision()
	{
		int layerMask = 1 << 8;
		layerMask = ~layerMask;

		RaycastHit hit;
		List<GameObject> hitSet = new List<GameObject>();
		for (int i = 0; i < NumberOfTraces; i++)
		{
			if (Physics.Raycast(transform.position, Quaternion.AngleAxis((-angle / 2f) + (angle * i /(NumberOfTraces - 1)), Vector3.forward) * spotLight.transform.forward * range, out hit, Mathf.Infinity, layerMask))
			{
				Debug.DrawLine(
					transform.position,
					transform.position + Quaternion.AngleAxis((-angle / 2f) + (angle * i / (NumberOfTraces - 1)), Vector3.forward) * spotLight.transform.forward * range);

				GameObject other = hit.collider.gameObject;
				Block block = other.GetComponent<Block>();
				if (block)
				{
					SetAdd(ref hitSet, other);
				}
			}
		}

		if (litSet.Count == 0)
		{
			litSet = hitSet;
		}
		else
		{
			for (int i = 0; i < litSet.Count; i++)
			{
				if (!hitSet.Contains(litSet[i]))
				{
					SetRemove(ref litSet, litSet[i]);
					continue;
				}
			}
			foreach (GameObject hitObj in hitSet)
			{
				SetAdd(ref litSet, hitObj);
			}
		}
	}















	// List<Block>
	void SetAdd(ref List<GameObject> list, GameObject toAdd)
	{
		Block block = toAdd.GetComponent<Block>();
		if (block && !list.Contains(toAdd)) {
			block.SetLit(true);
			list.Add(toAdd);
		}
	}

	void SetRemove(ref List<GameObject> list, GameObject toRemove)
	{
		if (list.Contains(toRemove)) {
			Block block = toRemove.GetComponent<Block>();
			block.SetLit(false);
			list.Remove(toRemove);
		}
	}
}
