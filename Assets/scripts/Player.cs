using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

  private Rigidbody rb;
  private float transmissionContainer;

  public float playerSpeed;

  // Use this for initialization
  void Start () {
    rb = GetComponent<Rigidbody>();
    playerSpeed = 10f;
    transmissionContainer = 0f;
  }

  // Update is called once per frame
  void Update () {
  }

  void FixedUpdate() {
    float moveHorizontal = Input.GetAxis("Horizontal");
    float moveVertical = Input.GetAxis("Vertical");
    Vector3 force = new Vector3(moveHorizontal, 0.0f, moveVertical);
    rb.AddForce(force * playerSpeed);
  }

  void OnCollisionEnter(Collision col) {
    if(col.gameObject.tag == "Pilar") {
      Debug.Log("Time to Charge!!!!");
    }
  }

  void OnCollisionStay(Collision col) {
    if(col.gameObject.tag == "Pilar") {
      Debug.Log("Charging..." + transmissionContainer + "%");
      if (transmissionContainer < 100f) {
        transmissionContainer += 1.0f;
      }
    }
  }

  void OnCollisionExit(Collision col) {
    if(col.gameObject.tag == "Pilar") {
      Debug.Log("Left Pilar at " + transmissionContainer + "%");
      if (transmissionContainer < 100f) {
        transmissionContainer = 0f;
      }
    }
  }
}
