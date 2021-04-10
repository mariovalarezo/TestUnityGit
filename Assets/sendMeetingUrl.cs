using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sendMeetingUrl : MonoBehaviour,IAction
{

    public string meetingUrl;
    [SerializeField] GameObject uiMeeting;
    public void Activate()
    {
        uiMeeting.GetComponent<sendMessageController>().message = meetingUrl;
    }


}
