using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoVolcano : MonoBehaviour {
  [SerializeField]
  DemoLavaCloud lavaCloud;

  [SerializeField]
  Transform lavaCircle;

  [SerializeField]
  Transform lavaLine;

  [SerializeField]
  Transform smokeCircle;

  [SerializeField]
  Transform smokeLine;

  public void Activate() {
    lavaCloud.Activate();
  }
  public void Deactivate() {
    lavaCloud.Deactivate();
  }

  // Use this for initialization
  void Start () {
    Deactivate();
  }

  // Update is called once per frame
  void Update () {

  }
}

