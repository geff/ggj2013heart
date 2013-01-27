using UnityEngine;
using System.Collections;

public class Repository : MonoBehaviour
{
    public static Repository Instance;

    public int Life = 70;
    public Difficulty CurrentDifficulty = Difficulty.ImTooYoungToDie_1;
    public int XOffset = 0;
    public Vector3 Vecteur;
    public int NbModule = 0;

    // Use this for initialization
    void Start()
    {
        Instance = this;
        Vecteur = GameObject.Find("Rocher").transform.position;

        Vecteur.x += 55;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
