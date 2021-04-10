using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovileInteraction : MonoBehaviour
{

    [SerializeField] GameObject interactionDesk;
    [SerializeField] GameObject interctionMovil;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (interactionDesk.activeSelf)
        {
            interctionMovil.SetActive(true);
        }
        else {

            interctionMovil.SetActive(false);
        }



    }
}
