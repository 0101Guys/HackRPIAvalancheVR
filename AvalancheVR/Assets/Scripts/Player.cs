using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
    public void Kill()
    {
        GameManager.LoadDeadScreen();
    }
	
}
