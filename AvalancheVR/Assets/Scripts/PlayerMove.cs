using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour
{
    public float move_speed = 5;
    public float upwards_speed = 5f;

    public void Update()
    {
        float input_x = Input.GetAxis("Horizontal");
        float input_y = Input.GetAxis("Vertical");
        bool input_jump = Input.GetButton("Jump");

        transform.Translate(new Vector3(input_x, 0, input_y) * Time.deltaTime * move_speed);

        if (input_jump)
        {
            rigidbody.AddForce(Vector3.up * upwards_speed);

            // cap upwards velocity
            if (rigidbody.velocity.y > upwards_speed)
                rigidbody.velocity = new Vector3(rigidbody.velocity.x, upwards_speed, rigidbody.velocity.z);

        }



        // mouse rotation
        float euler_y = Input.GetAxis("Mouse X");
        transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.x, euler_y, transform.rotation.eulerAngles.z));
    }
}
