using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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
        if (collider.gameObject.transform.parent.GetComponent<Character>() != null)
        {
            if (this.TriggerType == global::TriggerType.Jump)
            {
                InputController.Instance.Jump();
            }
            else if (this.TriggerType == global::TriggerType.Landing)
            {
                InputController.Instance.Landing();
            }
            else if (this.TriggerType == global::TriggerType.Death)
            {
                InputController.Instance.Death();
            }
            else if (this.TriggerType == global::TriggerType.ModuleInstanciator)
            {
                InputController.Instance.InstanciateModule();
            }
        }
    }
}

public enum TriggerType
{
    Jump,
    Landing,
    ModuleInstanciator,
    Death
}
