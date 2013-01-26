using UnityEngine;
using System.Collections;

public class Trigger : MonoBehaviour
{
    public TriggerType TriggerType = TriggerType.ModuleInstanciator;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.GetComponent<Character>() != null)
        {

        }
    }
}

public enum TriggerType
{
    Jump,
    ModuleInstanciator
}
