using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequestLoadData : MonoBehaviour
{

    [SerializeField] private SetDataStand setDataStand;
    [HideInInspector] public bool active = true;

    [HideInInspector]  public int numStand;
    [SerializeField] public bool institucinal;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
           
                setDataStand.setStand(numStand, institucinal,active);          
                active = false;            
        }
    }
}
