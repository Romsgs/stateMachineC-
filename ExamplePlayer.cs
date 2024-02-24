using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    // public properties
    public Idle idleState;


    public float movementSpeed = 10f;
    // state machine 
    [HideInInspector] public Walking walkingState;
    // private properties 
    
    [HideInInspector] public StateMachine stateMachine; // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
    [HideInInspector] public Vector2 movementVector;
    [HideInInspector] public Rigidbody thisRigidbody;
    [HideInInspector] public Animator thisAnimator;
    // Start is called before the first frame update
    private void Awake() {
        thisRigidbody = GetComponent<Rigidbody>();
        thisAnimator = GetComponent<Animator>();
    }
    void Start() {
        // statemachine <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        stateMachine = new StateMachine();
        idleState = new Idle(this);
        walkingState = new Walking(this);
        stateMachine.ChangeState(idleState);
    }

    // Update is called once per frame
    void Update() {
        // create input vector
        bool isUp = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);
        bool isDown = Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow);
        bool isLeft = Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow);
        bool isRight = Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow);
        bool isSpace = Input.GetKey(KeyCode.Space);
        float InputY = isUp ? 1 : isDown ? -1 : 0;
        float InputX = isRight ? 1 : isLeft ? -1 : 0;
        float InputZ = isSpace ? 1 : 0;
        movementVector = new Vector2(InputX, InputY);
        float velocity = thisRigidbody.velocity.magnitude;
        float velocityRate = velocity / movementSpeed;
        thisAnimator.SetFloat("fVelocity", velocityRate);

        stateMachine.Update();

    }
    private void LateUpdate() {
        stateMachine.LateUpdate(); // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
    }
    private void FixedUpdate() {
        stateMachine.FixedUpdate(); // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
    }
    public Quaternion GetForward() {
        Camera camera = Camera.main;
        float eulerY = camera.transform.eulerAngles.y;
        return Quaternion.Euler(0, eulerY, 0);
    }
    public void rotateBodyToFaceInput() {
        Camera camera = Camera.main;
        Vector3 inputVector = new Vector3(movementVector.x, 0, movementVector.y);
        float eulerY = camera.transform.eulerAngles.y;
        Quaternion q1 = Quaternion.LookRotation(inputVector, Vector3.up);
        Quaternion q2 = Quaternion.Euler(0, eulerY, 0);
        Quaternion toRotation = q1 * q2;
        Quaternion newRotation = Quaternion.LerpUnclamped(transform.rotation, toRotation, 0.15f);
        thisRigidbody.MoveRotation(newRotation); 


    }
  // displays name of current state on game screen  // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
    void OnGUI() {
        GUI.Label(new Rect(5, 5, 200, 50), stateMachine.currentStateName); // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
    }

}
