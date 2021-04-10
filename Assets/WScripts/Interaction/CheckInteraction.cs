using UnityEngine;

public class CheckInteraction : MonoBehaviour
{
    [SerializeField] private float minInteractionDistance;

    [SerializeField] private GameObject originRay;

    private Ray ray;
    private bool canInteract;
    private ReceptorInteraction receptor;
    private UIInterfaceController uIInterface;

    [SerializeField] GameObject uiMobile;

    private void Start()
    {
        uIInterface = FindObjectOfType<UIInterfaceController>();
    }

    void Update()
    {
        CheckRaycast();
        if (canInteract)
        {
            //En esta región el personaje está viendo un objeto con el que puede interactuar
            if (Input.GetKeyDown(KeyCode.E))
            {
                receptor.Activate();
            }
        }
    }

    public void ActiveMobile()
    {
        receptor.Activate();
        
    }

    private void CheckRaycast()
    {
        ray = new Ray(originRay.transform.position, originRay.transform.forward);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.distance < minInteractionDistance)
            {
                receptor = hit.transform.gameObject.GetComponent<ReceptorInteraction>();

                if (receptor != null)
                {
                    uIInterface.showMessage(receptor.GetInteractionMessage());
                    canInteract = true;
                }
                else
                {
                    canInteract = false;
                    uiMobile.SetActive(false);
                }
            }
        }
    }
}
