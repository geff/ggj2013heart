using UnityEngine;
using System.Collections;

public class UserInterface : MonoBehaviour
{
    private GUIStyle guiStyle;
    private Vector3 startPosition = Vector3.zero;
    // Use this for initialization
    void Start()
    {
        guiStyle = new GUIStyle();
        guiStyle.fontSize = 23;
        GUI.color = Color.black;

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnGUI()
    {
        if (InputController.Instance.gameState == GameState.Playing)
        {
            if(startPosition == Vector3.zero)
                startPosition = Character.Instance.Model.localPosition;

            int x = (int)Mathf.Abs(Character.Instance.Model.localPosition.x - startPosition.x);

            GUI.Label(new Rect(10, 10, 300, 50), x.ToString() + " meters", guiStyle);
        }
    }
}
