using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plotLocations : MonoBehaviour
{
    public Transform compass;
    public float lat, lon;


    private float angleFromCoordinate(float lat1, float long1, float lat2, float long2)
    {
        lat1 *= Mathf.Deg2Rad;
        lat2 *= Mathf.Deg2Rad;
        long1 *= Mathf.Deg2Rad;
        long2 *= Mathf.Deg2Rad;

        float dLon = (long2 - long1);
        float y = Mathf.Sin(dLon) * Mathf.Cos(lat2);
        float x = (Mathf.Cos(lat1) * Mathf.Sin(lat2)) - (Mathf.Sin(lat1) * Mathf.Cos(lat2) * Mathf.Cos(dLon));
        float brng = Mathf.Atan2(y, x);
        brng = Mathf.Rad2Deg * brng;
        brng = (brng + 360) % 360;
        brng = 360 - brng;
        return brng;
    }


    //https://answers.unity.com/questions/1500577/gps-2d-compass-to-point-to-longitude-and-latitude.html

    // Update is called once per frame
    /**
    void Update()
    {
        float bearing = angleFromCoordinate(52.414220f, -1.856110f ,
            52.411960f, -1.817350f);

        compass.rotation = Quaternion.Slerp(compass.rotation, Quaternion.Euler(0, 0, Input.compass.magneticHeading + bearing), 100f);

        
    transform.position = Quaternion.AngleAxis(lon, -Vector3.up) * Quaternion.AngleAxis(lat, -Vector3.right) * new Vector3(0,0,1);
}*/

    public Transform target;
    public Gyroscope gyro;

    
    void Start()
    {
        gyro = Input.gyro;
        gyro.enabled = true;
    }
    void Update()
    {
        target.localRotation = gyro.attitude;
        target.Rotate(0f, 0f, 180f, Space.Self); // Swap "handedness" of quaternion from gyro.
        target.Rotate(90f, 180f, 0f, Space.World); // Rotate to make sense as a camera pointing out the back of your device.

        float deltaAngle = Mathf.DeltaAngle(Camera.main.transform.eulerAngles.y, target.eulerAngles.y);//where "myCamera" is the camera, controled by ArCore.

        target.eulerAngles = new Vector3(0, deltaAngle, 0);
    }

}
