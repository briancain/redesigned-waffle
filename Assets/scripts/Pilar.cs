using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pilar : MonoBehaviour {

  [SerializeField]
  GameObject emissionObject;

  private float nextActionTime = 0.0f;
  private float timer = 0f;
  private float generationCooldown = 2.0f;

  private AudioSource audio;
  [SerializeField]
  AudioClip emissionCreateClip;

  [SerializeField]
  ParticleSystem particleAnimator;

  private List<GameObject> transmissions;

  private bool generateTransmissions;

  public void startTransmissions() {
    generateTransmissions = true;
  }

  public void stopTransmissions() {
    generateTransmissions = false;
  }

  public void removeTransmissionOrbs() {
    foreach(var tr in transmissions) {
      Destroy(tr);
    }
    transmissions.Clear();

  }

  // Use this for initialization
  void Start () {
    audio = GetComponent<AudioSource>();
    transmissions = new List<GameObject>();
  }
  // Update is called once per frame
  void Update () {
    // Every few seconds, generate an Emission
    if (generateTransmissions) {
      timer += Time.deltaTime;
      if (timer >= generationCooldown) {
        timer = nextActionTime;
        GenerateEmission();
       }
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
    GameObject trsObj = Instantiate(emissionObject, dir, spawnRotation, transform);
    transmissions.Add(trsObj);

    audio.PlayOneShot(emissionCreateClip, 1f);
  }
}
