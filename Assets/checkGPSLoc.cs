using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkGPSLoc : MonoBehaviour
{
    float degreesLatitudeInMeters = 111132;
    float degreesLongitudeInMetersAtEquator = 111319.9f;

    private float GetLongitudeDegreeDistance(float latitude)
    {
        return degreesLongitudeInMetersAtEquator * Mathf.Cos(latitude * (Mathf.PI / 180));
    }

    void SpawnObject()
    {
        // Real world position of object. Need to update with something near your own location.
        float latitude = 52.414220f;
        float longitude = -1.856110f;
        
        // Real GPS Position - This will be the world origin.
        var gpsLat = GPSManager_NoCompass.Instance.latitude;
        var gpsLon = GPSManager_NoCompass.Instance.longitude;
        // GPS position converted into unity coordinates
        var latOffset = (latitude - gpsLat) * degreesLatitudeInMeters;
        var lonOffset = (longitude - gpsLon) * GetLongitudeDegreeDistance(latitude);

        // Create object at coordinates
        var obj = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        obj.transform.position = new Vector3(latOffset, 0, lonOffset);
        obj.transform.localScale = new Vector3(4, 4, 4);

    }

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(5);
        SpawnObject();

    }
}
