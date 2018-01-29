using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pilar : MonoBehaviour {

  [SerializeField]
  GameObject emissionObject;

  private float nextActionTime = 0.0f;
  private float period = 10f;

  private AudioSource audio;
  [SerializeField]
  AudioClip emissionCreateClip;

  [SerializeField]
  ParticleSystem particleAnimator;

  // Use this for initialization
  void Start () {
    audio = GetComponent<AudioSource>();
  }
  // Update is called once per frame
  void Update () {
    // Every few seconds, generate an Emission
    if (Time.time > nextActionTime ) {
        nextActionTime += period;
        GenerateEmission();
     }
  }

  void GenerateEmission() {
    Vector3 dir = transform.position;
    float randomXPosition = Random.Range(-5.0f, 5.0f);
    if (randomXPosition == 0f || randomXPosition == 1f) {
      // :D
      randomXPosition = 2f;
    }
    float randomZPosition = Random.Range(-5.0f, 5.0f);
    // x should be random
    dir.x += randomXPosition;
    dir.y = 1.3f;
    dir.z += randomZPosition;

    particleAnimator.Play();

    Quaternion spawnRotation = Quaternion.Euler(90,0,0);
    Instantiate(emissionObject, dir, spawnRotation, transform);
    audio.PlayOneShot(emissionCreateClip, 1f);
  }
}
