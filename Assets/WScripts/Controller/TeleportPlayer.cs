using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class TeleportPlayer : MonoBehaviour
{

    [SerializeField] Transform[] listSpawPoints;
    [SerializeField] GameObject player;

    VideoPlayer[] allVP;
    
    // Start is called before the first frame update
    void Start()
    {
        allVP = GameObject.FindObjectsOfType<VideoPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Teleport(int i)
    {
        Vector3 aux = listSpawPoints[i].transform.position;
        player.transform.eulerAngles = listSpawPoints[i].transform.eulerAngles;
        player.transform.position = aux;

        foreach (VideoPlayer video in allVP)
        {
            video.Pause();
        }
    }
}
