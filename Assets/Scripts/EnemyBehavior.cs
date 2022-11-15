using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    private Vector3 startPos;
    public float speed = 5f;
    private float frequency = 5f;
    private float magnitude = 5f;
    private float offset = 0f;

    // Start is called before the first frame update
    void Start()
    {
        startPos = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = startPos + transform.up * Mathf.Sin(Time.deltaTime * frequency + offset) * magnitude;
    }
}
