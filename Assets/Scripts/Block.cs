﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class Block : MonoBehaviour
{
	[Header("Config")]
	public bool UseExitForce;

	public static float ExitForceMultiplier = 0.65f;

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


	// Boost when exiting collider
	void OnCollisionExit(Collision other)
	{
		Rigidbody rbOther = other.transform.GetComponent<Rigidbody>();
		PlayerController ball = other.transform.GetComponent<PlayerController>();
		if (UseExitForce)
			rbOther.AddForce(ball.FakeVelocity.normalized * ExitForceMultiplier, ForceMode.Impulse);
	}
}
