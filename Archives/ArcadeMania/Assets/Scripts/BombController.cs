using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{

    [SerializeField] private float speed;
    CircleCollider2D bombCollider;
    private bool hit;

    float direction;

    private void Awake()
    {
        bombCollider = GetComponent<CircleCollider2D>();
    }

    private void Update()
    {
        if (hit) return;
        float movementSpeed = speed * Time.deltaTime;
        transform.Translate(movementSpeed, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        hit = true;
        bombCollider.enabled = false;
    }

    public void SetDirection(float _dir)
    {
        direction = _dir;
        gameObject.SetActive(true);
        hit = false;
        bombCollider.enabled = true;

        float localScaleX = transform.localScale.x;

        if (Mathf.Sign(localScaleX) != _dir)
        {
            localScaleX = -localScaleX;
        }

        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
    }

    private void Deactivate()
    {

    }

}
