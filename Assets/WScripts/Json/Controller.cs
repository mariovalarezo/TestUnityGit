using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;
using System.Runtime.InteropServices;
using UnityEditor;
using UnityEngine.Networking;

public class Controller : MonoBehaviour
{

    [DllImport("__Internal")]
    private static extern void SendMessageToWeb(string msg);

    private string path;
    private string jsonString;
    public bool desk;
    [SerializeField] GameObject uiMobile;
    public JsonClass data = new JsonClass();


    CursorController cc;


    bool k;

    // Start is called before the first frame update
    void Awake()
    {
        cc = GameObject.FindObjectOfType<CursorController>();

        StartCoroutine(GetRequest("https://casa-abierta-utpl-default-rtdb.firebaseio.com/tour-data.json"));
    //Load();        
    //SendMessageToWeb("UNITY::StartOn");
    
        DesactiveMobile();

        StartCoroutine(GetCedula("https://us-central1-casa-abierta-utpl.cloudfunctions.net/ValidateCI?ci=1104113889"));
    }


    public void Load()
    {
        data = JsonConvert.DeserializeObject<JsonClass>(Resources.Load<TextAsset>("Datos").ToString());
        SetDataStand[] objSetData = GameObject.FindObjectsOfType<SetDataStand>();
        objSetData[0].enabled = true;
        objSetData[1].enabled = true;
    }

    public void LoadJson(string jsString)
    {
        data = JsonConvert.DeserializeObject<JsonClass>(jsString);
        SetDataStand[] objSetData = GameObject.FindObjectsOfType<SetDataStand>();
        objSetData[0].enabled = true;
        objSetData[1].enabled = true;
    }

    public void DesactiveMobile()
    {
        /*
        desk = !data.isMobile;
        cc.isDesk = !data.isMobile;*/

        desk = false;
        cc.isDesk = false;
        if (desk)
        {
            uiMobile.SetActive(false);
        }
        else
        {

            ReceptorInteraction[] interactor = GameObject.FindObjectsOfType<ReceptorInteraction>();

            foreach (ReceptorInteraction item in interactor)
            {
                item.interactMessage = "Presione aqui para interactuar";
            }
            uiMobile.SetActive(true);
        }
    }

    public void ReceiveMessageFromWeb(string msg)
    {
        Debug.Log("Controller.ReceiveMessageFromWeb: " + msg);

    }

    public void ActiveMovile()
    {
        desk = !desk;
        DesactiveMobile();
    }

    public void sendMessage(string message)
    {
        //SendMessageToWeb(message);
        Application.OpenURL(message);
        // Debug.Log(message);
    }

    IEnumerator GetRequest(string uri)
    {

        
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {

            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            if (webRequest.isNetworkError)
            {
                Debug.Log(pages[page] + ": Error: " + webRequest.error);
            }
            else
            {
                
                jsonString = webRequest.downloadHandler.text;
                Debug.Log(jsonString);
                data = JsonConvert.DeserializeObject<JsonClass>(jsonString);
                SetDataStand[] objSetData = GameObject.FindObjectsOfType<SetDataStand>();
                objSetData[0].enabled = true;
                objSetData[1].enabled = true;
            }
        }
    }




    IEnumerator GetCedula(string uri)
    {


        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {

            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            if (webRequest.isNetworkError)
            {
                Debug.Log(pages[page] + ": Error: " + webRequest.error);
            }
            else
            {
                Debug.Log("La cedula es correcta " + webRequest.downloadHandler.text);
            }
        }
    }





}
