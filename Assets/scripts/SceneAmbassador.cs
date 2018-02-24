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

  [SerializeField]
  Title title;

  [SerializeField]
  Title gameover;

  [SerializeField]
  Pilar pilar;

  [SerializeField]
  GameObject titleObj;
  private GameObject titleObjClone;

  private AudioSource audio;
  private bool m_ToggleAudio;

  [SerializeField]
  bool m_Play;

  enum GameState {
    PRETITLE,
    TITLE,
    PREGAME,
    PLAYING,
    GAMEOVER
  }
  GameState state;

  void SetState(GameState newstate) {
    print(newstate.ToString());

    if (state == GameState.GAMEOVER) {
      //gameover.Hide();
    }

    switch(newstate) {
      case GameState.PRETITLE:
        StartTitle();
        break;
      case GameState.TITLE:
        DestroyTitle();
        players.Reset();
        bases.Reset();
        ShowTitle();
        gameover.Hide();
        pilar.removeTransmissionOrbs();
        break;
      case GameState.PREGAME:
        break;
      case GameState.PLAYING:
        HideTitle();
        pilar.startTransmissions();
        break;
      case GameState.GAMEOVER:
        pilar.stopTransmissions();
        gameover.Show();
        break;
    }

    state = newstate;
  }

  void Awake () {
    // initialize bindings
    initVars();
    InitPlayers();
    InitInput();

    SetState(GameState.PRETITLE);
  }

  void Update() {
    if (m_Play == true && m_ToggleAudio == true) {
      audio.Play();
      m_ToggleAudio = false;
    } else if (m_Play == false && m_ToggleAudio == true) {
      audio.Stop();
      m_ToggleAudio = false;
    }

    if (state == GameState.PLAYING) {
      Player endGame = players.checkPlayerScore();
      if (endGame != null) {
        SetState(GameState.GAMEOVER);
      }
    }
  }

  void initVars() {
    audio = GetComponent<AudioSource>();
    // TODO: Uncomment me before shipping pls :D
    //m_Play = true;
    audio.volume = 0.5f;
    m_ToggleAudio = true;
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
            if (state == GameState.PRETITLE) {
              SetState(GameState.TITLE);
            }
            else if (state == GameState.TITLE) {
              SetState(GameState.PLAYING);
            }

            // this might be screwy
            if (state == GameState.PLAYING) {
              // we just created a new player
              Player player = players.GetPlayer(actions);

              // assign it to a base and set its color
              player.SetBase(bases.GetBase());
            }
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

  void StartTitle() {
    titleObjClone = (GameObject)Instantiate(titleObj, new Vector3(0, 0, 0), Quaternion.identity);
  }

  void DestroyTitle() {
    Destroy(titleObjClone);
  }

  void ShowTitle() {
    title.Show();
  }
  void HideTitle() {
    title.Hide();
  }
}
