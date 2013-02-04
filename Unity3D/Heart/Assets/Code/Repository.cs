using UnityEngine;
using System.Collections;

public class Repository : MonoBehaviour
{
    public static Repository Instance;

    public int Life = 70;
    public Vector3 Vecteur;
    public int NbModule = 0;
    public bool SkipIntro = true;
    public float percent = 0f;
    public Module CurrentModule;

    public UnityEngine.Object[] ViewedModules;

    // Use this for initialization
    void Start()
    {
        Instance = this;
        Vecteur = GameObject.Find("Module Intro").transform.position;
        ViewedModules = new UnityEngine.Object[3];
        ViewedModules[0] = GameObject.Find("Module Intro").transform;

        Vecteur.x -= 26;

        if (SkipIntro && Camera.mainCamera.animation.isPlaying)
        {
            Camera.main.animation.Stop();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
