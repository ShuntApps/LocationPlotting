using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropAnchor : MonoBehaviour
{
    public float latitude;
    public float longitude;

    private void Start()
    {
        transform.position = Quaternion.AngleAxis(longitude, -Vector3.up) * Quaternion.AngleAxis(latitude, -Vector3.right) * new Vector3(0, 0, 1);
    }

    /*
    // Start is called before the first frame update
    IEnumerator Start()
    {
        // First, check if user has location service enabled
        if (!Input.location.isEnabledByUser)
            yield break;

        // Start service before querying location
        Input.location.Start();

        // Wait until service initializes
        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        // Service didn't initialize in 20 seconds
        if (maxWait < 1)
        {
            print("Timed out");
            yield break;
        }

        // Connection has failed
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            print("Unable to determine device location");
            yield break;
        }
        else
        {
            // Access granted and location value could be retrieved
            // print("Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude + " " + Input.location.lastData.altitude + " " + Input.location.lastData.horizontalAccuracy + " " + Input.location.lastData.timestamp);
        }

        // Stop service if there is no need to query location updates continuously
        //        Input.location.Stop();
        //      StartCoroutine("Start");
    }*/
    //corner store = 52.414220 -1.856110


    // Update is called once per frame
    void Update()
    {
        
    }

    /**
    Vector3 latLongToXY(float lat, float lon)
    {
    
        return new Vector3(x, 0, z);
    }*/
}
