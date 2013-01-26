using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DifficultyLevel : MonoBehaviour
{
    public Difficulty Difficulty;
    public List<Difficulty> DifficultyDependency;
    public List<int> NiveauMinimalVie;

    // Use this for initialization
    void Start()
    {
        DifficultyDependency = new List<Difficulty>();
        NiveauMinimalVie = new List<int>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
