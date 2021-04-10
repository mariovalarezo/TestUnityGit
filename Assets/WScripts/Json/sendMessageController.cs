using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sendMessageController : MonoBehaviour,IAction
{

    private Controller jController;

    public string message;
    void Start()
    {
        jController = GameObject.FindObjectOfType<Controller>();
    }


    public void Activate()
    {
        jController.sendMessage(message);
    }
}
