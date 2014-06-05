using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class MovePikeman : MonoBehaviour {

	public float MovementSpeed = 0.1f;
	public float RotationSpeed = 5f;
	public bool attack = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 direction = Vector3.zero;
		Vector3 speed = Vector3.zero;

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

		if(Input.GetButtonDown("Fire1")) {
			MovementSpeed = 0.2f;	
		}
		else if(Input.GetButtonUp("Fire1")) {
			MovementSpeed = 0.1f;
		}

		if(Input.GetButtonDown("Fire2")) {
			attack = true;	
		}
		else if(Input.GetButtonUp("Fire2")) {
			attack = false;
		}
		
		if (direction.sqrMagnitude > 0f) {

			speed = direction  * MovementSpeed;
			this.transform.position = speed + this.transform.position;
		}
	
		this.GetComponent<Animator>().SetBool("attack", attack);
		this.GetComponent<Animator>().SetFloat("runSpeed", speed.magnitude);
	}
}
