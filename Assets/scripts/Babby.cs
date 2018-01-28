using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Babby : MonoBehaviour {

	[SerializeField]
	MeshRenderer renderer;

	public Base _base;

	// Use this for initialization
	void Start () {
		renderer.material = _base.GetPlayerMaterial();
	}
	
	// Update is called once per frame
	void Update () {
		transform.rotation = Quaternion.LookRotation(-1 * transform.position);
	}
}
