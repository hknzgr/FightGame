using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float followSpeed;

    private Vector3 playerPos;
    private Vector3 distance;
    private Vector3 startPos;
    Vector3 desiredPos;


    void Start()
    {
        Application.targetFrameRate = 60;
        startPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        distance = transform.position - startPos;

    }


    private void Update()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform);
        playerPos += distance;

        desiredPos = Vector3.Lerp(transform.position, playerPos, followSpeed * Time.deltaTime);
        transform.position = desiredPos;
    }
}
