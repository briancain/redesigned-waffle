using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseManager : MonoBehaviour {

	List<Base> bases;

	[SerializeField]
  Base blueBase;

  [SerializeField]
  Base redBase;

  [SerializeField]
  Base greenBase;

  [SerializeField]
  Base yellowBase;

	int nextbase;

	void Awake () {
		bases = new List<Base>();
		bases.Add(blueBase);
		bases.Add(redBase);
		bases.Add(greenBase);
		bases.Add(yellowBase);
		
		Reset();
	}

	public Base GetBase() {
		var _base = bases[nextbase++];
		_base.Activate();
		return _base;
	}
	
	public void Reset() {
		if (bases == null) {
			return;
		}
		foreach(var _base in bases) {
			_base.Deactivate();
		}
		nextbase = 0;
	}
}
