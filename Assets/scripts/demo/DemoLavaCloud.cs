using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DemoLavaCloud : MonoBehaviour {

	[SerializeField]
	SpriteRenderer spriteRenderer;
	
	Tween fade_tween;
	Tween shake_tween;
	
	public void Activate() {
		spriteRenderer.enabled = true;

		// fade in
		if (fade_tween != null) {
			fade_tween.Kill();
		}

		Color _color = spriteRenderer.color;
		_color.a = 0;
		spriteRenderer.color = _color;

		fade_tween = DOTween.To(
			() => spriteRenderer.color.a,
			x => {
				Color color = spriteRenderer.color;
				color.a = x;
				spriteRenderer.color = color;
			},
			1,
			0.5f
		);

		// shake indefinitely
		shake_tween = transform.DOShakePosition(1,new Vector3(0.1f,0.618f,0f),20,80,false,false).SetLoops(-1);

	}
	public void Deactivate() {

		// fade out
		if (fade_tween != null) {
			fade_tween.Kill();
		}
		fade_tween = DOTween.To(
			() => spriteRenderer.color.a,
			x => {
				Color color = spriteRenderer.color;
				color.a = x;
				spriteRenderer.color = color;
			},
			0,
			0.3f
		);

		// stop shaking
		if (shake_tween != null) {
			shake_tween.Kill();
		}

		spriteRenderer.enabled = false;
	}
}
