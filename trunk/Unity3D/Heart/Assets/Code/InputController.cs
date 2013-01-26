using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour
{
    public static InputController Instance;
    public Character Character;
    private bool _wantToJump;

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

            percent = Input.GetAxis("Horizontal");

            Vector3 vecBaseSpeed = new Vector3(Character.BaseSpeed * Time.deltaTime, 0f,0f);
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
        _wantToJump = true;
    }
}
