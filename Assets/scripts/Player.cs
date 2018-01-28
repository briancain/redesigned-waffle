using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour {

  public Action OnTouchPillar = delegate () {};

  CharacterActionz actions;

  public void SetActionsSource(CharacterActionz actions) {
    this.actions = actions;
  }

  private Rigidbody rb;

  public float playerSpeed;

  // Use this for initialization
  void Start () {
    rb = GetComponent<Rigidbody>();
    playerSpeed = 20f;
  }

  // Update is called once per frame
  void Update () {
  }

  void FixedUpdate() {
    Vector3 force = new Vector3(actions.move.X, 0.0f, actions.move.Y);
    rb.AddForce(force * playerSpeed);
  }

  void OnCollisionEnter(Collision col) {
    if(col.gameObject.tag == "Pilar") {
      OnTouchPillar();
    }
  }
}
