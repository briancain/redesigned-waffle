using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;
using System;

public class PlayerManager : MonoBehaviour {

  public Action OnMagicEvent = delegate () {};

  Dictionary<CharacterActionz,Player> action_mapping;
  List<Player> active_players;

  [SerializeField]
  Player PlayerPrefab;

  // Use this for initialization
  void Awake () {
    action_mapping = new Dictionary<CharacterActionz,Player>();
    active_players = new List<Player>();
  }

  public void Reset() {
    if (action_mapping != null) {
      action_mapping.Clear();
    }

    if (active_players != null) {
      foreach(var player in active_players) {
        Destroy(player.gameObject);
      }
      active_players.Clear();
    }
  }

  public bool AreActionsMapped(CharacterActionz actions) {
    return action_mapping.ContainsKey(actions);
  }

  public bool MapActions(CharacterActionz actions) {
    if (AreActionsMapped(actions)) {
      return false;
    }

    if (active_players.Count == 4) {
      // no more left
      return false;
    }

    // create and assign a player
    var player = Instantiate(PlayerPrefab,new Vector3(active_players.Count * 2,0.5f,0),Quaternion.identity,transform);
    player.OnTouchPillar += Magic;
    player.SetActionsSource(actions);
    action_mapping.Add(actions,player);
    active_players.Add(player);

    return true;
  }

  void Magic() {
    OnMagicEvent();
  }

  // Update is called once per frame
  void Update () {
  }
}
