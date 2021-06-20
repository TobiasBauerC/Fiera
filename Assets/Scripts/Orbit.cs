using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Orbit : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform orbitAround;
    [SerializeField] private float angle = 0.0f;
    [SerializeField] private float xRadius = 1000;
    [SerializeField] private float yRadius = 1000;
    [SerializeField] private float speed = 0.05f;

    private Vector3 previousPosition;

    public float Speed
    {
        get
        {
            return (previousPosition - transform.position).magnitude / Time.fixedDeltaTime;
        }
    }

    private void Start()
    {
        float min = 0.0f;
        float max = Mathf.PI * 2;
        angle = Random.Range(min, max);
        previousPosition = transform.position;
    }

    private void FixedUpdate()
    {
        if(!orbitAround)
            return;

        float x = orbitAround.position.x + Mathf.Cos(angle) * xRadius;
        float y = orbitAround.position.y + Mathf.Sin(angle) * yRadius;

        rb.MovePosition(new Vector2(x, y));

        angle += speed * Time.fixedDeltaTime;

        if (angle > (Mathf.PI * 2))
        {
            angle -= (Mathf.PI * 2);
        }

        previousPosition = transform.position;
    }
}
