using UnityEngine;
using System.Collections;
using System;

public class InputController : MonoBehaviour
{
    public static InputController Instance;
    public Character Character;
    private bool _wantToJump;
    private bool _isLanding;
    public bool _isRunning = false;
    public Vector3 vec;
    private float scrollWheel = 0f;

    // Use this for initialization
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Character != null && Character.RunningCurve != null)
        {
            float percent = 0f;
            float percentLanding = 1f;

            if (Input.GetJoystickNames().Length == 0)
            {
                scrollWheel += Input.GetAxis("Mouse ScrollWheel");
                percent += scrollWheel;
                Debug.Log(percent);
            }
            else
            {
                percent = Input.GetAxis("Horizontal");
            }

            percent = Mathf.Clamp(percent, -1f, 1f);

            if (Camera.mainCamera.animation.isPlaying)
                return;

            if (!Character.animation.IsPlaying("landing"))
            {
                _isLanding = false;
            }

            if (_isLanding)
            {
                percentLanding = 0.02f;
            }

            Vector3 vecBaseSpeed = new Vector3(Character.BaseSpeed * Time.deltaTime * percentLanding, 0f, 0f);
            Vector3 vecRunningCurve = new Vector3(Character.RunningCurve.Evaluate(percent), 0f, 0f);
            Vector3 vecJumping = new Vector3(0f, 0f, 0f);

            if (Input.GetButton("Jump"))
                Jump();

            if (_wantToJump)
            {
                Debug.Log("Want to jump");
                vecJumping = new Vector3(0f, Character.JumpingHeight, 0f);
                _wantToJump = false;
            }


            if (percent != 0f)
            {
                if (!_isRunning)
                    Character.animation.Play("run");

                _isRunning = true;

                //Debug.Log("Horizontal : " + percent.ToString());
            }

            Vector3 vecMoving = Vector3.zero;

            if (_isRunning)
            {
                Vector3 vecX = vecBaseSpeed + vecRunningCurve;
                //vecX.x = Mathf.Clamp(vec.x, -6f, 0f);
                vec = vecX;

                vecMoving = vecX + vecJumping;

                /*

                float maxSpeed = 6;
                float weightRun = Math.Abs(vecX.x) / maxSpeed;
                float weightWalk = 1 - weightRun;

                //animation.Blend("walk", weightWalk, 0.1f);
                //animation.Blend("run", weightRun, 0.1f);

                Character.animation.Blend("walk", weightWalk, 0.1f);
                Character.animation.Blend("run", weightRun, 0.1f);

                Character.animation["walk"].layer = 1;
                Character.animation["run"].layer = 1;
                Character.animation.SyncLayer(1);
                */
                //Character.animation.Blend(

            }

            Character.rigidbody.AddForce(vecMoving);
        }
    }

    public void Jump()
    {
        Character.animation.Play("jump");
        _wantToJump = true;
    }

    public void Landing()
    {
        Character.animation.Play("landing");
        Character.animation.Play("run", AnimationPlayMode.Queue);

        _isLanding = true;
    }

    internal void Death()
    {
        Application.LoadLevel("Game_over");
    }
}
