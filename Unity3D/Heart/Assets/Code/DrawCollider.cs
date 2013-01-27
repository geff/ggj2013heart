using UnityEngine;
using System.Collections;

public class DrawCollider : MonoBehaviour
{
    public float Alpha = 0.5f;
    public Color Color = Color.yellow;

    // Use this for initialization
    void Start()
    {


    }


    // Update is called once per frame
    void Update()
    {


    }


    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(Color.r, Color.g, Color.b, Alpha);
        //Gizmos.DrawSphere(transform.position, 0.01f);


        Gizmos.matrix = transform.localToWorldMatrix;
        if (transform.collider != null)
            Gizmos.DrawCube(Vector3.zero, transform.collider.bounds.size);
    }
}
