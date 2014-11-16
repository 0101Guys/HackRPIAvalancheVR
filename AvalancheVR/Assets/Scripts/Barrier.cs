using UnityEngine;
using System.Collections;

public class Barrier : MonoBehaviour
{

    public float speed = 0.5f;

	public void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed);
    }

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            Player p = collider.GetComponent<Player>();
            p.Kill();
        }
    }
}
