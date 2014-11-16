using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour
{
    public float move_speed = 5f;
    public float upwards_speed = 15f;
    public float mouse_speed = 1f;

    public Camera left_cam;
    public Transform cam_rig;


    public void Update()
    {

        // mouse rotation
        float euler_y = cam_rig.rotation.eulerAngles.y + Input.GetAxis("Mouse X") * mouse_speed;
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
        if (input_jump)
        {
            rigidbody.AddForce(Vector3.up * upwards_speed * 50f * Time.deltaTime);

            // cap upwards velocity
            if (rigidbody.velocity.y > upwards_speed)
                rigidbody.velocity = new Vector3(rigidbody.velocity.x, upwards_speed, rigidbody.velocity.z);

        }


        
    }
}
