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
  private bool isStunned;

  [SerializeField]
  AudioClip scoreSound;

  private AudioSource audio;

  CharacterActionz actions;

  Base _base;

  // Use this for initialization
  void Start () {
    rb = GetComponent<Rigidbody>();
    playerSpeed = 10f;
    holdingEmission = false;
    isStunned = false;
    audio = GetComponent<AudioSource>();
  }

  public void SetBase(Base _base) {
    this._base = _base;
    meshRenderer.material = this._base.GetPlayerMaterial();

    transform.position = this._base.GetSpawnPoint().position;
  }

  // Update is called once per frame
  void Update () {
    if (actions.action.WasPressed && !isStunned) {
      Attack();
    }
  }

  void Attack() {
    // Animate rig to swing
    // play melee sound
    Debug.Log("Attacking");
  }

  void FixedUpdate() {
    if (!isStunned) {
      Vector3 movement = new Vector3(actions.move.X, 0.0f, actions.move.Y);
      rb.velocity = movement * playerSpeed;
    }
  }

  void OnTriggerEnter(Collider col) {
    switch(col.gameObject.tag) {
      case "Emission":
        if (!holdingEmission) {
          Destroy(col.transform.parent.gameObject);
          holdingEmission = true;
          playerSpeed = 5f;
        }
        break;
      case "base":
        // is this our base?
        if (_base == col.transform.parent.parent.GetComponent<Base>()) {
          // drop off any emissions we're carrying
          if (holdingEmission) {
            playerSpeed = 10f;
            holdingEmission = false;
            audio.clip = scoreSound;
            audio.Play();
          }
        }else{
          // just entered the opponents' base
        }
        break;
    }
  }

  void OnCollisionEnter(Collision col) {
    if(col.gameObject.tag == "Pilar") {
      OnTouchPillar();
    }

    if(col.gameObject.tag == "Player") {
      Debug.Log("Collide with player");
      // stun gameobject?
    }
  }
}
