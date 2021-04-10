using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInterfaceController : MonoBehaviour
{
    private Text messageText;

    [SerializeField] private float messageTime;
    [SerializeField] private GameObject messageGameObject;
    [SerializeField] private GameObject messageTextGameObject;
    [SerializeField] GameObject mobileButton;

    void Start()
    {
        messageText = messageTextGameObject.GetComponent<Text>();
        messageGameObject.SetActive(false);
    }
    void FixedUpdate()
    {
        clearMessage();
        
    }

    public void showMessage(string message)
    {
        messageText.text = message;
        messageGameObject.SetActive(true);
        mobileButton.SetActive(true);
    }

    public void clearMessage()
    {
        messageGameObject.SetActive(false);
        
    }



}
