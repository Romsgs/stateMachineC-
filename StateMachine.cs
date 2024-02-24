using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine {
    private State currentState;
    public string currentStateName { get; private set; }
    // current state

    // update, late, fixed
    public void Update() {
        currentState?.Update();
    }
    public void LateUpdate() {
        currentState?.LateUpdate();
    }
    public void FixedUpdate() {
        currentState?.FixedUpdate();
    }
    // changestate
    public void ChangeState(State newState) {
        currentState?.Exit();
        currentState = newState;
        currentStateName = newState?.name;
        newState?.Enter();
    }

}
