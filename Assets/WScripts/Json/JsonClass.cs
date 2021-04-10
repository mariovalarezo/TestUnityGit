using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class JsonClass
{
    public Json offer = new Json();
    public Branding branding = new Branding();
    public bool isMobile;
}

[SerializeField]
public class Json
{
    public Stand[] institutional;
    public Stand[] degrees;
    
}


[SerializeField]
public class Stand
{
    public string[] carrouselUrls;
    public string catalogueImage;
    public string catalogueUrl;
    public string id;
    public string meetingUrl;
    public string name;
    public string videoUrl;
    public string chat ;
    public string interest;

}

[SerializeField]
public class Branding
{
    public string[] images;
    public string[] videos;

}



[SerializeField]
public class StandObject
{
    public List<GameObject> images = new List<GameObject>();
    public GameObject zone ;
    public GameObject video;
    public GameObject chat;
    public GameObject catalogue;
    public GameObject meeting;
    public GameObject name;
    public GameObject interest;
    



    public StandObject(List<GameObject> images,GameObject zone, GameObject video, GameObject chat, GameObject catalogue,GameObject meeting,GameObject name,GameObject character)
    {
        this.images = images;
        this.zone = zone;
        this.video = video;
        this.chat = chat;
        this.catalogue = catalogue;
        this.meeting = meeting;
        this.name = name;
        this.interest = character;
        
    }

}



