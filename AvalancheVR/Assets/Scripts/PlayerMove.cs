﻿using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour
{
	public float move_speed = 5f;
	public float upwards_speed = 15f;
	private float wind_upwards_speed = 20f;
	public float mouse_speed = 1f;
	
	public Camera left_cam;
	public Transform cam_rig;
	
	private bool windBoostState = false;
	public float fuel = 500f;
	private const float maxFuel = 500f;


    // max height
    private float start_height = 0;
    private float max_height = 0;



    public void Start()
    {
        start_height = transform.position.y;
    }
	
	public void Update()
	{
		
		// mouse rotation
		float euler_y = cam_rig.rotation.eulerAngles.y + Input.GetAxis("Mouse X");
		cam_rig.rotation = Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.x, euler_y, transform.rotation.eulerAngles.z));
	}
	
	public void FixedUpdate()
	{
		float input_x = Input.GetAxis("Horizontal");
		float input_y = Input.GetAxis("Vertical");
		bool input_jump = Input.GetButton("Jump");
		
		
		// move
		Vector3 fwrd = left_cam.transform.rotation * Vector3.forward;
		Vector3 left = left_cam.transform.rotation * Vector3.left;
		transform.Translate(fwrd * input_y * Time.deltaTime * move_speed);
		transform.Translate(left * -input_x * Time.deltaTime * move_speed);
		
		
		
		// upwards 
		if (input_jump && ValidFuel())
		{
			rigidbody.AddForce(Vector3.up * upwards_speed * 50f * Time.deltaTime);
			DecreaseFuel();
			if (!audio.isPlaying) {
				audio.Play ();
			}
			// cap upwards velocity
			if (rigidbody.velocity.y > upwards_speed)
				rigidbody.velocity = new Vector3(rigidbody.velocity.x, upwards_speed, rigidbody.velocity.z);
			
		}

		if (!input_jump) {
			audio.Stop ();
		}
		
		if (windBoostState) {
			rigidbody.AddForce(Vector3.up * upwards_speed);
			Debug.Log ("Boost player");
			// cap upwards velocity
			if (rigidbody.velocity.y > wind_upwards_speed)
				rigidbody.velocity = new Vector3(rigidbody.velocity.x, upwards_speed, rigidbody.velocity.z);
		}


		// fuel
		IncreaseFuel();

        // max height
        max_height = Mathf.Max(max_height, transform.position.y);
	}
	

	public void SetWindBoostState(bool state) {
		windBoostState = state;
	}
	
	private void DecreaseFuel() {
		if (fuel > 0)
			fuel -= 4f;
	}
	
	private void IncreaseFuel() {
		if (fuel < maxFuel)
			fuel += 2f;
	}
	
	private bool ValidFuel() {
		if (fuel > 0f)
			return true;
		return false;
	}

    public float GetMaxHeightClimbed()
    {
        Debug.Log("here: " + (max_height - start_height));
        return max_height - start_height;
    }
}
