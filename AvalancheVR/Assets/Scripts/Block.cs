using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour 
{
    public bool moving = true;

    public void OnCollisionEnter(Collision col)
    {
        Block block = col.collider.GetComponent<Block>();
        if (block && block.moving) return;

		if (col.gameObject.tag == "Player") {
			// Kill player.
		}
        rigidbody.isKinematic = true;
        moving = false;
    }
}
