using UnityEngine;
using System.Collections;

public class MovePikeman : MonoBehaviour {

	public float MovementSpeed = 1f;
	public float RotationSpeed = 5f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 direction = Vector3.zero;
		if (Input.GetKey(KeyCode.W)) {
			direction = this.transform.forward;
		}
		if (Input.GetKey(KeyCode.S)) {
			direction += -this.transform.forward;
		}

		if (Input.GetKey(KeyCode.A)) {
			this.transform.Rotate(this.transform.up, RotationSpeed);
		}
		if (Input.GetKey(KeyCode.D)) {
			this.transform.Rotate(this.transform.up, -RotationSpeed);
		}

		if (direction.sqrMagnitude > 0f) {
			direction = direction.normalized;
			Vector3 speed = direction * Time.deltaTime * MovementSpeed;

			this.transform.position = speed + this.transform.position;

			this.GetComponent<Animator>().SetFloat("runSpeed", speed.magnitude);
		}
	}
}
