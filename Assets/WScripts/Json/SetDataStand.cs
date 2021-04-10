using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Video;

public class SetDataStand : MonoBehaviour
{
    private Controller jController;


    [SerializeField] GameObject objStandObjects;
    private List<StandObject> listStandObjects = new List<StandObject>();

    [SerializeField] GameObject objBranding;
    private List<GameObject> listBranding = new List<GameObject>();

    [SerializeField] GameObject objVideo;
    private List<GameObject> listVideo= new List<GameObject>();



    private bool institucional;
    private int numStand;

    [SerializeField] GameObject uiMeeting;
    

    private void Awake()
    {
        SetObjList(objStandObjects, listStandObjects);
        
    }


    void Start()
    {
        jController = GameObject.FindObjectOfType<Controller>();
        ActiveZones();
        
        if (objBranding)
        {
            SetBrandingVideo();
        }
    }

    private void SetBrandingVideo()
    {
        SetList(objBranding, listBranding);
        
        for (int i = 0; i < listBranding.Count; i++)
        {
            StartCoroutine(LoadImg(listBranding[i], jController.data.branding.images[i]));
           
        }


        SetList(objVideo, listVideo);

        for (int i = 0; i < listVideo.Count; i++)
        {
           
            listVideo[i].GetComponent<VideoPlayer>().url = jController.data.branding.videos[i];
            
        }

    }

    private void SetObjList(GameObject objStandObjects, List<StandObject> listObj)
    {
        foreach (Transform objStand in objStandObjects.transform)
        {
            List<GameObject> listObjImages = new List<GameObject>();
            SetList(objStand.GetChild(0).gameObject, listObjImages);

            StandObject standObjectAux = new StandObject(listObjImages, objStand.GetChild(1).gameObject, objStand.GetChild(2).gameObject,
                objStand.GetChild(3).gameObject, objStand.GetChild(4).gameObject, objStand.GetChild(5).gameObject,
                objStand.GetChild(6).gameObject, objStand.GetChild(7).gameObject);

            listObj.Add(standObjectAux);
        }

    }

    private void SetList(GameObject obj, List<GameObject> list)
    {
        foreach (Transform child in obj.transform)
        {
            list.Add(child.gameObject);
        }
    }


    private void ActiveZones()
    {
        int numInstitucionales = 0;
        int numAcademicos = 0;


        for (int i = 0; i < listStandObjects.Count; i++)
        {
            GameObject Zone = listStandObjects[i].zone;

            if (Zone.GetComponent<RequestLoadData>().institucinal)
            {
                Zone.GetComponent<RequestLoadData>().numStand = numInstitucionales;
                numInstitucionales++;
            }
            else
            {
                Zone.GetComponent<RequestLoadData>().numStand = numAcademicos;
                numAcademicos++;
            }



            if (numInstitucionales > jController.data.offer.institutional.Length || numAcademicos > jController.data.offer.degrees.Length)
            {
                Zone.GetComponent<RequestLoadData>().active = false;
                Zone.transform.position = new Vector3(Zone.transform.position.x, Zone.transform.position.y + 1f, Zone.transform.position.z);
                Zone.GetComponent<MeshCollider>().isTrigger = false;
            }
            else
            {
                if (Zone.GetComponent<RequestLoadData>().institucinal)
                {
                    listStandObjects[i].name.GetComponent<TextMeshPro>().text = jController.data.offer.institutional[i].name;
                }
                else
                {
                    listStandObjects[i].name.GetComponent<TextMeshPro>().text = jController.data.offer.degrees[i].name;
                }
           
            }

        }


        

    }


    public void setStand(int i, bool institucional, bool active)
    {
        numStand = i;
        this.institucional = institucional;

        if (active)
        {
            SetData(i, institucional);
        }

    }

    public void SetData(int i, bool institucional)
    {

        //Asignar datos segun tipo de stand


        Stand[] typeStand = jController.data.offer.degrees;
        if (institucional)
        {
            typeStand = jController.data.offer.institutional;
        }
        


        //Imagenes ----------
        int aux = 0;
        foreach (string ImageUrl in typeStand[i].carrouselUrls)
        {
            if (!ImageUrl.Equals(""))
            {
                StartCoroutine(LoadImg(listStandObjects[i].images[aux], ImageUrl));
                listStandObjects[i].images[aux].gameObject.SetActive(false);

                aux++;
            }
        }


        listStandObjects[i].images[0].gameObject.SetActive(true);

        for (int j = aux; j < 3; j++)
        {
            Destroy(listStandObjects[i].images[j].gameObject);
        }


        //Videos--------

        string linkVideo = typeStand[i].videoUrl;
        if (!linkVideo.Equals(""))
        {
            listStandObjects[i].video.GetComponent<VideoPlayer>().url = linkVideo;
        }

        //Interest------

        listStandObjects[i].interest.GetComponent<sendMessageController>().message = typeStand[i].interest;

        //Catalogue-------

        listStandObjects[i].catalogue.GetComponent<AbrirLink>().link = typeStand[i].catalogueUrl;
        StartCoroutine(LoadImg(listStandObjects[i].catalogue, typeStand[i].catalogueImage));

        //Nombre-----
        listStandObjects[i].name.GetComponent<TextMeshPro>().text = typeStand[i].name;

        //Meeting------
        listStandObjects[i].meeting.GetComponent<sendMeetingUrl>().meetingUrl = typeStand[i].meetingUrl;

        //uiMeeting.GetComponent<sendMessageController>().message = typeStand[i].meetingUrl;

        //Chat-----
        listStandObjects[i].chat.GetComponent<sendMessageController>().message = typeStand[i].chat;
    }

    IEnumerator LoadImg(GameObject imagenInfografia, string urlImg)
    {
        UnityWebRequest imgRequest = UnityWebRequestTexture.GetTexture(urlImg);
        yield return imgRequest.SendWebRequest();
        if (imgRequest.isNetworkError || imgRequest.isHttpError)
        {
            Debug.LogError(imgRequest.error);
            yield break;
        }
        imagenInfografia.GetComponent<Renderer>().material.mainTexture = DownloadHandlerTexture.GetContent(imgRequest);
    }

    public void ChangeImage(int nextImage)
    {

        for (int i = 0; i < listStandObjects[numStand].images.Count; i++)
        {
            
            listStandObjects[numStand].images[i].gameObject.SetActive(false);
        }
        listStandObjects[numStand].images[nextImage].gameObject.SetActive(true);
    }
}
