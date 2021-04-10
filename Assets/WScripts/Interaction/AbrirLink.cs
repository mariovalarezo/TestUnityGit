using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AbrirLink : MonoBehaviour,IAction
{  
    [SerializeField] public string link;
    public bool mIsAppLeft;

    public void Activate()
    {
        //Application.ExternalEval("window.open('" + link + "');");

        if (mIsAppLeft)
        {
            mIsAppLeft = false;
        }
        else
        {
            Application.OpenURL(link);
        }
        
        
        
    }


    private void OnApplicationFocus(bool focus)
    {
        mIsAppLeft = !focus;
    }

    private void OnApplicationPause(bool pause)
    {
        mIsAppLeft = pause;
    }
}
