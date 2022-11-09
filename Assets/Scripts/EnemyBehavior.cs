using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    private Vector3 startPos;
    public float speed = 5f;
    private float magnitude;
    private float offset;
    private float frequency;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = startPos * Mathf.Sin(Time.time * frequency + offset) * magnitude;
    }
}
