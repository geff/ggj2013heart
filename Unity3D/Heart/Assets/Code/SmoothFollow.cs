using UnityEngine;
using System.Collections;

public class SmoothFollow : MonoBehaviour
{
    public Transform Character;
    public float Factor = 10;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 target = new Vector3(Character.position.x, transform.position.y, transform.position.z);

        transform.position = Vector3.Lerp(transform.position, target, Factor * Time.deltaTime);
        transform.LookAt(Character.position);
    }
}
