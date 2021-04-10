using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{

    [SerializeField] UIPanelController uiIndicaciones;
    [SerializeField] UIPanelController uiMapa;

    bool auxUIMapa;
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {

            uiIndicaciones.Activate();

        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            uiMapa.Activate();
            //ActiveDesactiveUIMapa();
        }


    }


    public void ActiveDesactiveUIMapa()
    {

        if (auxUIMapa)
        {
            uiMapa.Activate();
        }
        else
        {
            uiMapa.DesactivarTodo();   
        }

        auxUIMapa = !auxUIMapa;
    }

}
