    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceptorInteraction : MonoBehaviour
{
    [SerializeField] public  string interactMessage;
    [SerializeField]  private GameObject[] objectsWithActions;

    public void Activate()
    {     
        foreach (GameObject o in objectsWithActions) {
            o.GetComponent<IAction>().Activate();
        }

    }
    public string GetInteractionMessage()
    {
        return interactMessage;
    }
}
