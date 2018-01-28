using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pilar : MonoBehaviour {

  [SerializeField]
  GameObject emissionObject;

  private float nextActionTime = 0.0f;
  private float period = 3f;

  // Use this for initialization
  void Start () {
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
    float randomXPosition = Random.Range(-3.0f, 3.0f);
    float randomZPosition = Random.Range(-3.0f, 3.0f);
    // x should be random
    dir.x += randomXPosition;
    dir.y = 1.5f;
    dir.z += randomZPosition;

    Quaternion spawnRotation = Quaternion.Euler(90,0,0);
    Instantiate(emissionObject, dir, spawnRotation, transform);
  }
}
