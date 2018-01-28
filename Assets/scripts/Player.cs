using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour {

  [SerializeField]
  MeshRenderer meshRenderer;

  public Action OnTouchPillar = delegate () {};
  public void SetActionsSource(CharacterActionz actions) {
    this.actions = actions;
  }
  public float playerSpeed;

  private Rigidbody rb;
  private bool holdingEmission;
  CharacterActionz actions;

  Base _base;

  // Use this for initialization
  void Start () {
    rb = GetComponent<Rigidbody>();
    playerSpeed = 10f;
    holdingEmission = false;
  }

  public void SetBase(Base _base) {
    this._base = _base;
    meshRenderer.material = this._base.GetPlayerMaterial();

    transform.position = this._base.GetSpawnPoint().position;
  }

  // Update is called once per frame
  void Update () {
  }

  void FixedUpdate() {
    Vector3 movement = new Vector3(actions.move.X, 0.0f, actions.move.Y);
    rb.velocity = movement * playerSpeed;
  }

  void OnCollisionEnter(Collision col) {
    if(col.gameObject.tag == "Pilar") {
      OnTouchPillar();
    }

    if(col.gameObject.tag == "Emission" &&
        holdingEmission == false) {
      Destroy(col.transform.parent.gameObject);
      holdingEmission = true;
      playerSpeed = 5f;
    }
  }
}
