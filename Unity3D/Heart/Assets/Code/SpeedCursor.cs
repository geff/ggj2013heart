using UnityEngine;
using System.Collections;

public class SpeedCursor : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float x =  -Repository.Instance.percent * 4.85f;
        float newX = Mathf.Lerp(this.transform.localPosition.x, x, 10f * Time.deltaTime);
            
        this.transform.localPosition = new Vector3(newX, this.transform.localPosition.y, this.transform.localPosition.z);
    }
}
