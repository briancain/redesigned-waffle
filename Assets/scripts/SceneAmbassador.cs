using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;

public class SceneAmbassador : MonoBehaviour {

  [SerializeField]
  InputManager input;

  [SerializeField]
  PlayerManager players;

  [SerializeField]
  BaseManager bases;

  enum GameState {
    TITLE,
    PREGAME,
    PLAYING,
    GAMEOVER
  }
  GameState state;

  void SetState(GameState newstate) {
    print(newstate.ToString());

    switch(newstate) {
      case GameState.TITLE:
        players.Reset();
        bases.Reset();
        ShowTitle();
        break;
      case GameState.PREGAME:
        HideTitle();
        break;
      case GameState.PLAYING:
      break;
      case GameState.GAMEOVER:
      break;
    }

    state = newstate;
  }

  void Awake () {

    // initialize bindings
    InitPlayers();
    InitInput();

    SetState(GameState.TITLE);
  }

  void InitInput() {
    input.OnDevicePressX += delegate (CharacterActionz actions) {
      if (state == GameState.GAMEOVER) {
        SetState(GameState.TITLE);
      } else {
        // if we're in anything other than ENDGAME,
        // and this device is NOT mapped to a player
        // assign this device to an inactive player
        // and activate it
        if (!players.AreActionsMapped(actions)) {
          if (players.MapActions(actions)) {
            if (state == GameState.TITLE) {
              SetState(GameState.PLAYING);
            }

            // we just created a new player
            Player player = players.GetPlayer(actions);

            // assign it to a base and set its color
            player.SetBase(bases.GetBase());
          }
        }
      }
    };
  }

  void InitPlayers() {
    players.OnMagicEvent += delegate() {
      SetState(GameState.GAMEOVER);
    };
  }

  void ShowTitle() {

  }
  void HideTitle() {

  }
}
