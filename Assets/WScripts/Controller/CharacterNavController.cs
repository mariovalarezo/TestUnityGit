using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterNavController : MonoBehaviour
{
    NavMeshAgent nav;
    Animator npcAnim;
    public Transform[] step;
    int cont = 0;
    float delay = 0.1f;
    float timeBeforeChange;
    int aux;

    void Start()
    {
        nav = gameObject.GetComponent<NavMeshAgent>();
        npcAnim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        nav.SetDestination(step[cont].position);


        Vector3 ditance = (transform.position - step[cont].position);

        if (ditance.magnitude < 1)
        {
            //npcAnim.SetBool("isWalking", false);

            if (timeBeforeChange < Time.time)
            {
                timeBeforeChange = Time.time + delay;
                if (aux == 1)
                {
                    cont++;
                    aux -= 2;
                }
                aux++;
            }
        }
        else
        {
            //npcAnim.SetBool("isWalking", true);
        }

        if (cont >= step.Length)
        {
            cont = 0;
        }
    }
}
