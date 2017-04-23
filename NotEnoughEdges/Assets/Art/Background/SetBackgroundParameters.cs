using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetBackgroundParameters : MonoBehaviour {

    public Renderer backgroundRenderer;

    public Transform player;
	
	// Update is called once per frame
	void Update () {
        MaterialPropertyBlock block = new MaterialPropertyBlock();
        backgroundRenderer.GetPropertyBlock(block);
        block.SetVector("_PlayerPos", player.position);
        backgroundRenderer.SetPropertyBlock(block);
	}
}
