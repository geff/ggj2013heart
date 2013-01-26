using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Module : MonoBehaviour
{
    public string Nom;
    public Difficulty Difficulty = Difficulty.ImTooYoungToDie_1;
    public Transform ModulePrefab;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
}


public enum Difficulty : int
{
    ImTooYoungToDie_1 = 1,
    HeyNotTooRough_2 = 2,
    HurtMePlenty_3 = 3,
    UltraViolence_4 = 4,
    Nightmare_5 = 5
}