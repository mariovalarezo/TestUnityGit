using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageController : MonoBehaviour,IAction
{
    [SerializeField] private SetDataStand setDataStand;
    public static int nextImage = 0;

    [SerializeField] bool rigth;
    [SerializeField] int numImagenes;

    public void Activate()
    {
        if (rigth)
        {
            nextImage++;
        }
        else
        {
            nextImage--;
        }
        if (nextImage == -1)
        {
            nextImage = numImagenes-1;
        }
        if (nextImage == numImagenes)
        {
            nextImage = 0;
        }
        setDataStand.ChangeImage(nextImage);
    }

}
