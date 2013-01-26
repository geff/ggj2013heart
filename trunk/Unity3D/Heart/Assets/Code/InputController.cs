using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour
{
    public Character Character;

    // Use this for initialization
    void Start()
    {

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
            {
                vecJumping = new Vector3(0f, Character.JumpingHeight, 0f);
                Debug.Log("Jump");
            }


            Vector3 vecMoving = vecBaseSpeed + vecRunningCurve + vecJumping;
            Debug.Log((vecMoving).ToString());

            //Character.rigidbody.velocity = vecMoving;

            Character.rigidbody.AddForce(vecMoving);
            //Character.transform.Translate(vecBaseSpeed + vecRunningCurve + vecJumping);
        }
    }
}
