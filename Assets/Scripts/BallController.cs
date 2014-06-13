using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody))]

public class BallController : MonoBehaviour {
	public float MaxVelocity = 10;
	public float Torque = 1;

	private Vector3 inputDirection;

	// Use this for initialization
	void Start () {
		rigidbody.maxAngularVelocity = MaxVelocity;
	}

	void FixedUpdate () {
		Vector3 torqueAxis = Vector3.zero;
		if (Application.platform == RuntimePlatform.Android ) {
			inputDirection = new Vector3 (Input.acceleration.y, 0, -Input.acceleration.x);
			torqueAxis = new Vector3 (inputDirection.z, 0, -inputDirection.x) * Torque;
		}
		else if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer) {
			inputDirection = Vector3.ClampMagnitude(new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical")),1);
			torqueAxis = new Vector3 (-inputDirection.x, 0, -inputDirection.z) * Torque;
		}
		rigidbody.AddTorque(torqueAxis, ForceMode.Force);
		
	}

	// Update is called once per frame
	void Update () {
	
	}

//	void OnCollisionEnter () {
//		Handheld.Vibrate ();
//	}
}
