using UnityEngine;
using System.Collections;

public class Repository : MonoBehaviour
{
    public static Repository Instance;

    public int Life = 70;
    public Difficulty CurrentDifficulty = Difficulty.ImTooYoungToDie_1;

    // Use this for initialization
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
