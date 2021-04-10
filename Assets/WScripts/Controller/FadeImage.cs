using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeImage : MonoBehaviour
{
    [SerializeField] private Image imagen;
    float timeLeft = 4.0f;

    private void Awake()
    {
        imagen.enabled = true;
    }

    void Start()
    {
        
        imagen.canvasRenderer.SetAlpha(1.0f);
        fade();
    }


    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            Destroy(gameObject);
        }
    }

    public void fade()
    {
        imagen.CrossFadeAlpha(0,4,false);
     
    }
    
}
