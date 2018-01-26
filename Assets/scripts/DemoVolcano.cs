using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoVolcano : MonoBehaviour {
  [SerializeField]
  Transform lavaCloud;

  [SerializeField]
  Transform lavaCircle;

  [SerializeField]
  Transform lavaLine;

  [SerializeField]
  Transform smokeCirlce;

  [SerializeField]
  Transform smokeLine;

  public void Activate() {
    lavaCloud.gameObject.SetActive(true);
  }
  public void Deactivate() {
    lavaCloud.gameObject.SetActive(false);
  }

  // Use this for initialization
  void Start () {
    Deactivate();
  }
  
  // Update is called once per frame
  void Update () {
    
  }
}

