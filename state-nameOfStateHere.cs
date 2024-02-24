using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
public class Jump : State {
    public PlayerController controller;
    public Jump(PlayerController controller) : base("Jump") {
        this.controller = controller;
    }
    public override void Enter() {
        base.Enter();
    }
    public override void Exit() {
        base.Exit();
    }
    public override void Update() {
        base.Update();
    }
    public override void FixedUpdate() {
        base.FixedUpdate();
    }
    public override void LateUpdate() {
        base.LateUpdate();
    }

}
