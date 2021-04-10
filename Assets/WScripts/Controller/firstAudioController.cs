using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firstAudioController : MonoBehaviour
{

    [SerializeField] GameObject videoRange;
    [SerializeField] AudioSource firstAudio;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameObject.GetComponent<AudioSource>().isPlaying)
        {
            videoRange.SetActive(true);
        }


    }

    public void DesactiveAudio()
    {
        firstAudio.Stop();
    }
}
