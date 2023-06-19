using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    Transform followObject;
    [SerializeField, Range(0, 1)]
    float time;
    [SerializeField]
    Vector3 minPos;
    [SerializeField]
    Vector3 maxPos;
    Camera camera;

    private void Start()
    {
        camera = GetComponent<Camera>();
        var markObject = GameObject.FindGameObjectsWithTag("Mark");
        if (markObject[0].transform.position.x > markObject[1].transform.position.x)
        {
            minPos = markObject[1].transform.position;
            maxPos = markObject[0].transform.position;
        }
        else
        {
            minPos = markObject[0].transform.position;
            maxPos = markObject[1].transform.position;
        }
    }

    void Update()
    {
        var temp = followObject.position;
        temp.x = Mathf.Clamp(temp.x, minPos.x + camera.orthographicSize, maxPos.x - camera.orthographicSize );
        temp.z= Mathf.Clamp(temp.z, minPos.z + camera.orthographicSize, maxPos.z - camera.orthographicSize);
        transform.position = Vector3.Lerp(transform.position, temp + new Vector3(0f,60f,0f), time);
    }

}
