using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Title : MonoBehaviour {

	[SerializeField]
	Vector3 startpos;

	[SerializeField]
	Vector3 endpos;

	Vector3 showpos;

	void Awake() {
		showpos = transform.position;
	}

	public void Show() {
		transform.position = startpos;
		transform.DOMove(showpos,0.618f);
	}

	public void Hide() {
		transform.DOMove(endpos,0.5f);
	}
}
