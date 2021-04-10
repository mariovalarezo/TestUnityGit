using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcSaludo : MonoBehaviour
{
    Transform player;
    Animator standAnimator;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
        standAnimator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        Vector3 proximidad = transform.position - player.position;

        if (proximidad.magnitude < 2)
        {
            standAnimator.SetBool("Proximidad", true);
        }
        else
        {
            standAnimator.SetBool("Proximidad", false);
        }
    }
}
