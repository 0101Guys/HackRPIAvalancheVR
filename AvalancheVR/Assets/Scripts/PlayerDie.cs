using UnityEngine;
using System.Collections;

public class PlayerDie : MonoBehaviour 
{
    public ScreenFadeInOut fader;

    public void Kill()
    {
        fader.InstantBlack();
    }
}
