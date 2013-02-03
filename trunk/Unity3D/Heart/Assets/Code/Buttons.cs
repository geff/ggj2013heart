using UnityEngine;
using System.Collections;

public class Buttons : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnMouseUp()
    {
        if(this.name == "ButtonCredits")
            Application.LoadLevel("Credits");
        else if (this.name == "ButtonStartGame")
            Application.LoadLevel("Scene");
    }
}
