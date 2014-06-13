using UnityEngine;
using System.Collections;

public class DeathTrigger : MonoBehaviour {

	public Transform RedRespawn;
	public Transform BlueRespawn;

	void Awake () {
		// Disable screen dimming
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
	}

	void OnTriggerEnter (Collider col) {
		if (col.gameObject.GetComponent<BallController>() != null) {
			if (col.gameObject.name == "Red Player")
				col.gameObject.transform.position = RedRespawn.position;
			else if (col.gameObject.name == "Blue Player")
				col.gameObject.transform.position = BlueRespawn.position;
			col.gameObject.rigidbody.angularVelocity = Vector3.zero;
			col.gameObject.rigidbody.velocity = Vector3.zero;
			Handheld.Vibrate ();
		}
	}
}
