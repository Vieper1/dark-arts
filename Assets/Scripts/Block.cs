using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
	private bool isLit;
	private BoxCollider myCollider;

    void Start()
    {
		myCollider = GetComponent<BoxCollider>();
    }

    void Update()
    {
		if (isLit) {
			myCollider.isTrigger = false;
		} else {
			myCollider.isTrigger = true;
		}
    }

	public void SetLit(bool value)
	{
		isLit = value;
	}
}
