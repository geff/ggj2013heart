using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour
{
    public static Character Instance;
    public float BaseSpeed = 30;
    public AnimationCurve RunningCurve = AnimationCurve.Linear(-1f, 0f, 1f, 5f);
    public float JumpingHeight;
    private float defaultFriction = 0.15f;
    public Transform Model;

    // Use this for initialization
    void Start()
    {
        Model = this.transform.GetChild(0);
        defaultFriction = Model.collider.material.staticFriction;
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
        FrictionModifier frictionModifier = collision.gameObject.GetComponent<FrictionModifier>();

        if (frictionModifier != null)
        {
            Debug.Log("Friction Modifer");

            this.collider.material.staticFriction = frictionModifier.Friction;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        FrictionModifier frictionModifier = collision.gameObject.GetComponent<FrictionModifier>();

        if (frictionModifier != null)
        {
            this.collider.material.staticFriction = defaultFriction;
        }
    }
}
