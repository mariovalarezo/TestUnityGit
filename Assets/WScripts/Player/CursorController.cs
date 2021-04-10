using UnityEngine;


public class CursorController : MonoBehaviour
{
    PlayerController playerController;
    Controller jController;

    public bool isDesk;

    void Awake()
    {
        jController = gameObject.GetComponent<Controller>();
        playerController = gameObject.GetComponent<PlayerController>();
        //HideCursor();
    }

    private void Start()
    {
       
    }

    //Esconder cursor en juego
    public void HideCursor()
    {
        if (isDesk)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }


        playerController.enabled = true;

    }

    //Mostrar cursor en juego
    public void ShowCursor()
    {
        if (isDesk)
        {

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }



        playerController.enabled = false;

    }
}
