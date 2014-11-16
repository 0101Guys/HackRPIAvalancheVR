using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour
{
    public int move_speed = 5;

    public void Update()
    {
        float input_x = Input.GetAxis("Horizontal");
        float input_y = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * input_y * move_speed * Time.deltaTime);
    }
}
