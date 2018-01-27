using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DemoAmbassador : MonoBehaviour {
  [SerializeField]
  DemoInput input;

  [SerializeField]
  DemoCharacter character;

  [SerializeField]
  DemoVolcano volcano;

  [SerializeField]
  DemoCamera _camera;

  // Use this for initialization
  void Awake () {
    RegisterInputHandlers();
  }

  void RegisterInputHandlers() {
    input.OnActionPressed += delegate() {
      character.SetPose("action");
      volcano.Activate();
      _camera.ShakeIt();
    };
    input.OnActionReleased += delegate() {
      character.SetPose("idle");
      volcano.Deactivate();
    };
  }
  
  // Update is called once per frame
  void Update () {
    
  }
}
