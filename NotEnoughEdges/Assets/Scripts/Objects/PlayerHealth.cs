using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {
    public delegate void Thing();
    public event Thing onDeath = delegate { };
    public event Thing onWin;

    public void Die()
    {
        onDeath();
    }

    public void Win()
    {
        onWin();
    }
}
