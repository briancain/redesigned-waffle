using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DemoCamera : MonoBehaviour {

	[SerializeField]
	Camera _camera;

	public void ShakeIt() {
		_camera.DOShakePosition(0.2f, 0.1f);
	}
}
