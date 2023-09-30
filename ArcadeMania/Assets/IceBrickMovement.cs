using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBrickMovement : MonoBehaviour
{
    [SerializeField] float minSpeed = 1f, maxSpeed = 8f;

    void Update()
    {
        transform.position += Vector3.down * Random.Range(minSpeed, maxSpeed) * Time.deltaTime;
    }
}