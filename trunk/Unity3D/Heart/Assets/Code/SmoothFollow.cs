using UnityEngine;
using System.Collections;

public class SmoothFollow : MonoBehaviour
{
    public Transform Character;
    public float Factor = 10;
	public bool LookAtActivated = true;
    private Vector3 prevLookAtVector = Vector3.zero;
	
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 target = new Vector3(Character.position.x, transform.position.y, transform.position.z);

        if (prevLookAtVector == Vector3.zero)
            prevLookAtVector = Character.position;

        transform.position = Vector3.Lerp(transform.position, target, Factor * Time.deltaTime);

        Vector3 newLookAtVector = Vector3.Lerp(prevLookAtVector, Character.position, 10f * Time.deltaTime);
        prevLookAtVector = newLookAtVector;

    	if(LookAtActivated)
            transform.LookAt(newLookAtVector);
    }
}
