using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnAwake : MonoBehaviour {
	
	void Awake () {
		Destroy(this.gameObject);
	}
	
}
