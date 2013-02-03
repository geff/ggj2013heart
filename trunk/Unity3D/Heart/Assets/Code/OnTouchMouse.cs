using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OnTouchMouse : MonoBehaviour
{
    void Update()
    {
        RaycastHit hit = new RaycastHit();
        for (int i = 0; i < Input.touchCount; ++i)
        {
			Debug.Log(Input.touchCount);
			
            if (Input.GetTouch(i).phase.Equals(TouchPhase.Began))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
                if (Physics.Raycast(ray, out hit))
                {
                    hit.transform.gameObject.SendMessage("OnMouseDown");
                }
            }
            else if (Input.GetTouch(i).phase.Equals(TouchPhase.Ended))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
                if (Physics.Raycast(ray, out hit))
                {
                    hit.transform.gameObject.SendMessage("OnMouseUp");
                }
            }
        }
    }
}
