using UnityEngine;
using UnityEngine.Video;

public class PlayVideoProximity : MonoBehaviour
{
    [SerializeField] VideoPlayer vPlayerAway;
    private VideoPlayer vPlayer;
    private Vector3 proximity;
    private Transform playerTransform;

    [SerializeField] private float distance;
    [SerializeField] AudioSource backMusic;

    private void Awake()
    {
        if (vPlayerAway)
        {
            vPlayer = vPlayerAway;
        }
        else {
            vPlayer = gameObject.GetComponent<VideoPlayer>();
        }

        
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        backMusic = GameObject.FindGameObjectWithTag("music").GetComponent<AudioSource>();


    }

    void Update()
    {
        proximity = transform.position - playerTransform.position;
        //Si la distancia entre el jugador y el objeto es menor a la distancia establecida entra al metodo
        if (proximity.magnitude < distance)
        {
            Activate_Desesactivate();
        }

    }

    public void Activate_Desesactivate()
    {
        //Si es menor 0.5 mas se reproduce el videoUrl
        if (proximity.magnitude < distance - 0.5)
        {
            vPlayer.Play();
            backMusic.Pause();
        }
        //Si deja de ser menor el videoUrl se pausa
        else
        {
            vPlayer.Pause();
            backMusic.UnPause();
        }
    }
}
