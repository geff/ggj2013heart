using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Module : MonoBehaviour
{
    public string Nom;
    public Difficulty Difficulty;
    public Transform ModulePrefab;
    public int NiveauVieMinimum = 0;

    // Use this for initialization
    void Start()
    {
        Difficulty = global::Difficulty.ImTooYoungToDie_1;
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