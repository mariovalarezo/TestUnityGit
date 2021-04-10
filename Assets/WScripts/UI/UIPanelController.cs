using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPanelController : MonoBehaviour, IAction
{
    [SerializeField] GameObject uiPanel;
    CursorController cc;
    [SerializeField] bool activeFirst;
    UITraficController uicontroller;
    
    void Start()
    {
        cc = GameObject.FindObjectOfType<CursorController>();
        uicontroller = GameObject.FindObjectOfType<UITraficController>();

        uiPanel.transform.localScale = new Vector3(0, 0, 0);

        if (activeFirst)
        {
            ActivateFirst();
        }
    }


    public void Activate()
    {

        if (!uicontroller.uiActive || gameObject.CompareTag("uiTP"))
        {

            LeanTween.scale(uiPanel, new Vector3(1, 1, 1), 0.5f);
            cc.ShowCursor();
            uicontroller.Active();
        }

    }
    public void ActivateFirst()
    {
        
        if (!uicontroller.uiActive)
        {
            LeanTween.scale(uiPanel, new Vector3(1, 1, 1), 0f);
            cc.ShowCursor();
            uicontroller.Active();
        }       

    }
    public void DesactivarTodo()
    {
        LeanTween.scale(uiPanel, new Vector3(0, 0, 0), 0.3f);
        cc.HideCursor();
        uicontroller.Desactive();


    }
    public void Desctivar()
    {
        LeanTween.scale(uiPanel, new Vector3(0, 0, 0), 0.3f);      
        uicontroller.Desactive();

    }


}
