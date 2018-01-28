using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffsetUVRandomly : MonoBehaviour {

    private Renderer rend;

	// Use this for initialization
	void Start () {
        rend = GetComponent<Renderer>();
        Debug.Log(Random.Range(0,1.0f));
	}
	
	// Update is called once per frame
	void Update () {
        rend.material.SetTextureOffset("_MainTex", new Vector2(Random.Range(0, 1.0f), Random.Range(0, 1.0f)));
    }
}
