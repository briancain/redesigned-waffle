using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour {

  [SerializeField]
  MeshRenderer meshRenderer;

  [SerializeField]
  Transform holdplace;

  [SerializeField]
  Animator animator;

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

  [SerializeField]
  BoxCollider leftclaw;
  [SerializeField]
  BoxCollider rightclaw;

  private AudioSource audio;
  [SerializeField]
  AudioClip emissionPickupClip;
  [SerializeField]
  AudioClip stunnedClip;
  [SerializeField]
  AudioClip attackClip;

  CharacterActionz actions;

  Base _base;

  Vector3 movement;

  float stun_time;
  [SerializeField]
  float stunTimeout = 0.5f;

  [SerializeField]
  float normSpeed = 20f;

  [SerializeField]
  float slowSpeed = 10f;

  // Use this for initialization
  void Start () {
    rb = GetComponent<Rigidbody>();
    playerSpeed = normSpeed;
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
    if (isStunned) {
      if (Time.time > stun_time + stunTimeout) {
        isStunned = false;
      }
    }

    if (actions.action.WasPressed && !isStunned) {
      Attack();
    }

    holdplace.gameObject.SetActive(holdingEmission);

    if (movement.magnitude > 0) {
      transform.rotation = Quaternion.LookRotation(-1f * movement.normalized);
    }
  }

  void Attack() {
    // Animate rig to swing
    // play melee sound
    if (!holdingEmission) {
      animator.SetTrigger("Attack");
      audio.PlayOneShot(attackClip, 0.9f);
    }
  }

  void FixedUpdate() {
    if (!isStunned) {
      movement = new Vector3(actions.move.X, 0.0f, actions.move.Y);
      rb.velocity = movement * playerSpeed;
    }else{
      rb.velocity = Vector3.zero;
    }

    var doit = animator.GetCurrentAnimatorStateInfo(0).IsName("Attack");
    leftclaw.enabled = doit;
    rightclaw.enabled = doit;
  }

  void OnTriggerEnter(Collider col) {
    switch(col.gameObject.tag) {
      case "Emission":
        if (!holdingEmission) {
          Destroy(col.transform.parent.gameObject);
          holdingEmission = true;
          playerSpeed = slowSpeed;
          animator.SetBool("HasOrb",holdingEmission);
          animator.SetTrigger("PickedUpOrb");
          audio.PlayOneShot(emissionPickupClip, 1f);
        }
        break;
      case "base":
        // is this our base?
        if (_base == col.transform.parent.parent.GetComponent<Base>()) {
          // drop off any emissions we're carrying
          if (holdingEmission) {
            playerSpeed = normSpeed;
            holdingEmission = false;
            audio.clip = scoreSound;
            audio.Play();
            animator.SetBool("HasOrb",false);
            animator.SetTrigger("DroppedOrbOff");
          }
        }else{
          // just entered the opponents' base
        }
        break;
      case "claw":
        if (col == leftclaw || col == rightclaw) {
          // trigger associated with our own claw, so ignore it
          print("hit our own claw");
          break;
        }
        print("hit a claw");
        animator.SetTrigger("Hit");
        audio.PlayOneShot(stunnedClip, 5f);
        isStunned = true;
        stun_time = Time.time;

        if (holdingEmission) {
          // drop that thang
          animator.SetBool("HasOrb",false);
          holdingEmission = false;
          playerSpeed = normSpeed;
        }
        break;
    }
  }

  void OnCollisionEnter(Collision col) {
    if(col.gameObject.tag == "Pilar") {
      //OnTouchPillar();
    }

    if(col.gameObject.tag == "Player") {
      //Debug.Log("Collide with player");
      // stun gameobject?
    }
  }
}
