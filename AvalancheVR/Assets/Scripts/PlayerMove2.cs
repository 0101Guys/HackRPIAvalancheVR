using UnityEngine;
using System.Collections;

public class PlayerMove2 : MonoBehaviour {
	public float move_speed = 5;
	public float upwards_speed = 5f;
	private bool windBoostState = false;
	private bool dead = false;
	private GameObject diePos;
	public float fuel = 3000f;
	private const float maxFuel = 3000f;

	void Awake() {
		diePos = GameObject.Find ("DiePosition");
	}

	public void Update()
	{
		float input_x = Input.GetAxis("Horizontal");
		float input_y = Input.GetAxis("Vertical");
		bool input_jump = Input.GetButton("Jump");
		
		transform.Translate(new Vector3(input_x, 0, input_y) * Time.deltaTime * move_speed);
		
		if (input_jump && ValidFuel ())
		{
			rigidbody.AddForce(Vector3.up * upwards_speed);
			DecreaseFuel();
			// cap upwards velocity
			if (rigidbody.velocity.y > upwards_speed)
				rigidbody.velocity = new Vector3(rigidbody.velocity.x, upwards_speed, rigidbody.velocity.z);
			
		}

		if (windBoostState) {
			rigidbody.AddForce(Vector3.up * upwards_speed);
			
			// cap upwards velocity
			if (rigidbody.velocity.y > upwards_speed)
				rigidbody.velocity = new Vector3(rigidbody.velocity.x, upwards_speed, rigidbody.velocity.z);
		}

		// Kill player;
		if (dead) {
			Debug.Log ("rotating player towards dead position");
			Vector3 targetDir = diePos.transform.position - transform.position;
			Vector3 newRotation = Vector3.RotateTowards (Vector3.forward, targetDir, Time.deltaTime, 0f);
			transform.rotation = Quaternion.LookRotation (newRotation);	
		}

		// Debug Kill
		if (Input.GetKeyDown (KeyCode.J)) {
			KillPlayer();
		}
		// Passively Increase FUel
		IncreaseFuel();


		// mouse rotation
		float euler_y = Input.GetAxis("Mouse X");
		transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.x, euler_y, transform.rotation.eulerAngles.z));
	}

	public void SetWindBoostState(bool state) {
		windBoostState = state;
	}

	private void DecreaseFuel() {
		if (fuel > 0f)
			fuel -= 3f;
	}

	private void IncreaseFuel() {
		if (fuel < maxFuel) 
			fuel += 1f;
	}

	private bool ValidFuel() {
		if (fuel > 0f) 
			return true;
		return false;
	}

	public void KillPlayer() {
		if (diePos) {
			rigidbody.AddForce ((diePos.transform.position - transform.position) * 30f);
		}
		dead = true;
	}

}
