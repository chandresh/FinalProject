using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBrickMovement : MonoBehaviour
{
    [SerializeField] float speed = 5f;

    void Update()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;
    }
}