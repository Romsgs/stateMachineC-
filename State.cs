using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    // name
    public readonly string name;
    //constructor
    protected  State(string name)
    {
        this.name = name;
    }

    // enter
    public virtual void Enter()
    {

    }
    // exit
    public virtual void Exit() { }
    // update
    public virtual void Update() { }
    // lateUpdate
    public virtual void LateUpdate() { }
    // fixedUpdate
    public virtual void FixedUpdate() { }
}
