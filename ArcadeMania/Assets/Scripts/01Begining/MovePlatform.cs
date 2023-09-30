using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    [SerializeField] Transform pointA, pointB;
    [SerializeField] float speed = 1f;
    private bool movingToB = true;

    void Update()
    {
        // Move the platform back and forth between pointA and pointB
        Transform target = movingToB ? pointB : pointA;
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);

        if (Vector3.Distance(transform.position, target.position) < 0.001f)
        {
            movingToB = !movingToB;
        }
    }

}
