using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CycleVisibility : MonoBehaviour {

    public bool enabledOnStart = true;
    public float offWaitTime = 1.0f;
    public float onWaitTime = 1.0f;

	// Use this for initialization
	void Start () {
        StartCoroutine("cycleVisibility");
        GetComponent<Renderer>().enabled = enabledOnStart;
    }

    IEnumerator cycleVisibility(){
        for (;;){
            yield return new WaitForSeconds(offWaitTime);
            GetComponent<Renderer>().enabled = true;
            yield return new WaitForSeconds(onWaitTime);
            GetComponent<Renderer>().enabled = false;
        }
    }
}
