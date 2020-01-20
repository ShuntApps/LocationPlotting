using UnityEngine;
using System.Collections;

public class gyro : MonoBehaviour
{

    Vector3 angle = Vector3.zero;
    TextMesh text;
    
    void Start()
    {
        text = GetComponentInChildren<TextMesh>();
    }

    void Update()
    {
        angle.y = Input.acceleration.x * 360;
        transform.rotation = Quaternion.Euler(angle);
        text.text = Input.acceleration.x.ToString();
    }
}
