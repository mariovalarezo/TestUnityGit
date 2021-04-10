using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExclamacionController : MonoBehaviour
{

    Vector3 proximidad;
    [SerializeField] float distancia;
    [SerializeField] GameObject exclamacion;
    // Start is called before the first frame update
    void Start()
    {
        LeanTween.move(exclamacion, exclamacion.transform.position + new Vector3(0, 0.1f, 0), 0.5f).setLoopPingPong();
    }

    // Update is called once per frame
    void Update()
    {

        if (GameObject.FindGameObjectWithTag("Player"))
        {
            proximidad = transform.position - GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position;

            if (proximidad.magnitude < distancia)
            {
                ActDes();

            }
        }


    }

    public void ActDes()
    {
        if (proximidad.magnitude < distancia - 0.5)
        {
           
            LeanTween.scale(gameObject, new Vector3(0f, 0f, 0f), 0.1f);
        }
        else
        {
            LeanTween.scale(gameObject, new Vector3(1f, 1f, 1f), 0.4f);

        }



    }
}
