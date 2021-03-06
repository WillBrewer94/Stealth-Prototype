﻿using UnityEngine;
using InControl;
using System.Collections;

[RequireComponent(typeof(Player))]
public class PlayerInput : MonoBehaviour {
    InputDevice device;
    InputControl control;

    Player player;
    public PlayerActions playerActions;

    void Start() {
        player = GetComponent<Player>();
        playerActions = CreateWithDefaultBindings();
    }

    void Update() {
        player.SetDirectionalInput(playerActions.Move);

        if(playerActions.Jump.WasPressed) {
            player.OnJumpInputDown();
        }

        if(playerActions.Jump.WasReleased) {
            player.OnJumpInputUp();
        }

        if(playerActions.Interact.WasPressed) {
            player.OnInteractInputDown();
        }
    }

    //=========================
    //        Bindings 
    //=========================
    PlayerActions CreateWithDefaultBindings() {
        PlayerActions playerActions = new PlayerActions();

        playerActions.Up.AddDefaultBinding(Key.UpArrow);
        playerActions.Down.AddDefaultBinding(Key.DownArrow);
        playerActions.Left.AddDefaultBinding(Key.LeftArrow);
        playerActions.Right.AddDefaultBinding(Key.RightArrow);

        playerActions.Up.AddDefaultBinding(Key.W);
        playerActions.Down.AddDefaultBinding(Key.S);
        playerActions.Left.AddDefaultBinding(Key.A);
        playerActions.Right.AddDefaultBinding(Key.D);

        playerActions.Jump.AddDefaultBinding(Key.Space);
        playerActions.Interact.AddDefaultBinding(Key.F);

        playerActions.Left.AddDefaultBinding(InputControlType.LeftStickLeft);
        playerActions.Right.AddDefaultBinding(InputControlType.LeftStickRight);
        playerActions.Up.AddDefaultBinding(InputControlType.LeftStickUp);
        playerActions.Down.AddDefaultBinding(InputControlType.LeftStickDown);

        playerActions.ListenOptions.IncludeUnknownControllers = true;
        playerActions.ListenOptions.MaxAllowedBindings = 4;
        playerActions.ListenOptions.UnsetDuplicateBindingsOnSet = true;
        
        return playerActions;
    }
}
