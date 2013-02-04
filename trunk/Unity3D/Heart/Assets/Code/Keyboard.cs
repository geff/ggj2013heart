using UnityEngine;
using System.Collections;

public class Keyboard : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //-- Ecran_titre
        //--> Space : Scene
        //--> Return : Credits

        //-- Credits
        //--> Return : Ecran_titre

        //-- SceneDeath
        //--> Space : Ecran_Titre

        string nextScene = string.Empty;

        if (Application.loadedLevelName == "Ecran_Titre")
        {
            if (Application.platform != RuntimePlatform.Android)
            {
                if (Input.GetButtonDown("Fire1"))
                    nextScene = "Scene";
                if (Input.GetButtonDown("Fire2"))
                    nextScene = "Credits";

                if (Input.GetKey(KeyCode.Space))
                    nextScene = "Scene";
                if (Input.GetKey(KeyCode.Return))
                    nextScene = "Credits";
            }

            if (Input.GetKeyDown(KeyCode.Escape))
                Application.Quit();
        }
        else if (Application.loadedLevelName == "Scene")
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                nextScene = "Ecran_Titre";

            if (Input.GetKey(KeyCode.W))
                InputController.Instance.InstanciateModule();
        }
        else if (Application.loadedLevelName == "Credits")
        {
            if (Input.GetKey(KeyCode.Space) || Input.GetButtonDown("Fire1"))
                nextScene = "Ecran_Titre";
        }
        else if (Application.loadedLevelName == "Game_over")
        {
            if (Input.GetKey(KeyCode.Space) || Input.GetButtonDown("Fire1"))
                nextScene = "Ecran_Titre";
        }

        if (!string.IsNullOrEmpty(nextScene))
            Application.LoadLevel(nextScene);
    }
}
