using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour
{
    public static InputController Instance;
    public Character Character;
    private bool _wantToJump;
    private bool _isLanding;

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

            percent = Input.GetAxis("Horizontal");


            if (!Character.animation.IsPlaying("landing"))
            {
                _isLanding = false;
            } 
            
            if (_isLanding)
            {
                percentLanding = 0.02f;
            }

            Vector3 vecBaseSpeed = new Vector3(Character.BaseSpeed * Time.deltaTime * percentLanding, 0f,0f);
            Vector3 vecRunningCurve = new Vector3(Character.RunningCurve.Evaluate(percent), 0f,0f);
            Vector3 vecJumping = new Vector3(0f, 0f, 0f);

            if (Input.GetButton("Jump"))
                Jump();

            if (_wantToJump)
            {
                Debug.Log("Want to jump");
                vecJumping = new Vector3(0f, Character.JumpingHeight, 0f);
                _wantToJump = false;
            }


            Vector3 vecMoving = vecBaseSpeed + vecRunningCurve + vecJumping;

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
}
