using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class CameraMove : MonoBehaviour
{
    public float smoothSpeed;
    public Vector3 offset;
    public GameObject Target;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 DesiredPosition = offset + Target.transform.position;

        transform.position = Vector3.Lerp(transform.position, DesiredPosition, smoothSpeed);

        transform.LookAt(Target.transform.position);
    }
}
