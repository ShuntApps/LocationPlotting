using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class placeGPSObjs : MonoBehaviour
{
    GPSManager_NoCompass gpsManager;
    public Transform arrow;
    public GameObject obj;

    // Start is called before the first frame update
    void Start()
    {
        gpsManager = GetComponent<GPSManager_NoCompass>();

        GPSEncoder.SetLocalOrigin(new Vector2(gpsManager.latitude, gpsManager.longitude));
        Vector3 newPos = GPSEncoder.GPSToUCS(52.410210f, -1.825330f);
        obj = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        obj.transform.position = newPos;
        obj.transform.localScale = new Vector3(1, 1, 1);
        Debug.Log(obj.transform.position.magnitude);
    }

    //Get start GPS, set localorigin to that
    //Place primitive in spot for checking
    //if primitive is too far, display error
    // elese draw arrow and use lookAt to point towards


    // Update is called once per frame
    void Update()
    {
        if(obj)
        {
            arrow.LookAt(obj.transform.position);
        }
        
    }
}
