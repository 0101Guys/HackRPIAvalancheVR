using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour 
{
    public bool moving = true;

    public void OnCollisionEnter(Collision col)
    {
        Block block = col.collider.GetComponent<Block>();
        if (block && block.moving) return;

        rigidbody.isKinematic = true;
        moving = false;
    }
}
