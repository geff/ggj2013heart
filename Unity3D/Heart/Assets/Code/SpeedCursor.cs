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
        float x =  -(Repository.Instance.percent * 4.9f);
        this.transform.localPosition = new Vector3(x, this.transform.localPosition.y, this.transform.localPosition.z);
    }
}
