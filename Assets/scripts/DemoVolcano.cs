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

  [SerializeField]
  AudioClip explosionClip;
  AudioSource explosionSource;

  public void Activate() {
    lavaCloud.Activate();
    explosionSource.Play();
  }
  public void Deactivate() {
    lavaCloud.Deactivate();
  }

  // Use this for initialization
  void Start () {
    // create audio source for explosions
    explosionSource = gameObject.AddComponent<AudioSource>();
    explosionSource.clip = explosionClip;
    explosionSource.playOnAwake = false;

    Deactivate();
  }

  // Update is called once per frame
  void Update () {

  }
}

