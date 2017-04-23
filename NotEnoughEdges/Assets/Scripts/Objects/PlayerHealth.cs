using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {
    public delegate void OnDeath();
    public event OnDeath onDeath = delegate { };

    public void Die()
    {
        onDeath();
    }
}
