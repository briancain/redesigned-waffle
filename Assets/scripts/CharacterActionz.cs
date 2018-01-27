using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;

public class CharacterActionz : PlayerActionSet {

	public PlayerAction up;
	public PlayerAction down;
	public PlayerAction left;
	public PlayerAction right;

	public PlayerTwoAxisAction move;
	public PlayerAction action;

	public CharacterActionz() {
		up = CreatePlayerAction("up");
		down = CreatePlayerAction("down");
		left = CreatePlayerAction("left");
		right = CreatePlayerAction("right");

		action = CreatePlayerAction("action");

		move = CreateTwoAxisPlayerAction(left,right,down,up);
	}
}
