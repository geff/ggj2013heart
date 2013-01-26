using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour
{
    public float BaseSpeed = 30;
    public AnimationCurve RunningCurve = AnimationCurve.Linear(-1f, 0f, 1f, 5f);
    public float JumpingHeight;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
}
