using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoCharacter : MonoBehaviour {
	[SerializeField]
	Transform actionPose;
	
	[SerializeField]
	Transform idlePose;

	public void SetPose(string pose) {
		switch(pose) {
			case "action":
				// show the action pose
				actionPose.gameObject.SetActive(true);
				idlePose.gameObject.SetActive(false);
			break;
			default:
				// show the normal pose
				idlePose.gameObject.SetActive(true);
				actionPose.gameObject.SetActive(false);
				break;
		}
	}

	// Use this for initialization
	void Start () {
		SetPose("idle");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
