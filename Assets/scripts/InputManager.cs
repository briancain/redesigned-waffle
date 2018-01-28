using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;
using System;

public class InputManager : MonoBehaviour {
  public Action<CharacterActionz> OnDevicePressX = delegate (CharacterActionz a) {};

  List<InputDevice> devices;
  Dictionary<InputDevice,CharacterActionz> deviceMap;

  public CharacterActionz GetActions(InputDevice device) {
    if (deviceMap.ContainsKey(device)) {
      return deviceMap[device];
    }
    return null;
  }

  void Awake() {
    devices = new List<InputDevice>();
    deviceMap = new Dictionary<InputDevice,CharacterActionz>();

    // bind to device add/remove events
    InControl.InputManager.OnDeviceDetached += OnDeviceDetached;
    InControl.InputManager.OnDeviceAttached += OnDeviceAttached;

    foreach(InputDevice device in InControl.InputManager.Devices) {
      OnDeviceAttached(device);
    }
  }

  void OnDeviceAttached(InputDevice device) {
    print("device attached: " + device.Name);
    devices.Add(device);

    var actionz = new CharacterActionz();

    actionz.Device = device;

    actionz.action.AddDefaultBinding(Key.Return);
    actionz.action.AddDefaultBinding(InputControlType.Action1);

    Key[] upkeys = {Key.UpArrow,Key.W};
    actionz.up.AddDefaultBinding(upkeys);
    actionz.up.AddDefaultBinding(InputControlType.DPadUp);
    actionz.up.AddDefaultBinding(InputControlType.LeftStickUp);

    Key[] downkeys = {Key.DownArrow,Key.S};
    actionz.down.AddDefaultBinding(downkeys);
    actionz.down.AddDefaultBinding(InputControlType.DPadDown);
    actionz.down.AddDefaultBinding(InputControlType.LeftStickDown);

    Key[] leftkeys = {Key.LeftArrow,Key.A};
    actionz.left.AddDefaultBinding(leftkeys);
    actionz.left.AddDefaultBinding(InputControlType.DPadLeft);
    actionz.left.AddDefaultBinding(InputControlType.LeftStickLeft);

    Key[] rightkeys = {Key.RightArrow,Key.D};
    actionz.right.AddDefaultBinding(rightkeys);
    actionz.right.AddDefaultBinding(InputControlType.DPadRight);
    actionz.right.AddDefaultBinding(InputControlType.LeftStickRight);

    deviceMap.Add(device,actionz);
  }

  void OnDeviceDetached(InputDevice device) {
    print("device detached: " + device.Name);
    devices.Remove(device);

  }

  void Update() {
    var x= 0;
    foreach(InputDevice device in deviceMap.Keys) {
      var actions = deviceMap[device];

      if (actions.action.WasPressed) {
        OnDevicePressX(actions);
      }
      x++;
    }
  }
}
