using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DemoInput : MonoBehaviour {

	public Action OnActionPressed;
	public Action OnActionReleased;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("space")) {
			if (OnActionPressed != null ){
				OnActionPressed();
			}
		}else if (Input.GetKeyUp("space")) {
			if (OnActionReleased != null) {
				OnActionReleased();
			}
		}
	}
}
