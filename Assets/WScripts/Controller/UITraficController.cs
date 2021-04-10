using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITraficController : MonoBehaviour
{

    public bool uiActive = false;

    public void Active()
    {
        uiActive = true;
    }

    public void Desactive()
    {
        uiActive = false;
    }

}
