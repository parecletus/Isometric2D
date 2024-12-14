using System;
using Unity.Mathematics;
using UnityEngine;

public class cam : MonoBehaviour
{
    public Transform tr;

    private float xInput;
    private float yInput;
    public Vector2 camspeed;
    public float maxspeed;

    void Update()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");
        speed(xInput, yInput);
        transform.position = new Vector3(transform.position.x + speed(xInput, yInput).x, transform.position.y + speed(xInput, yInput).y, transform.position.z);
    }


    private Vector2 speed(float x, float y)
    {
        camspeed.x = +x;
        camspeed.y = +y;
        float newspeedx = Mathf.Abs(camspeed.x) > maxspeed ? maxspeed * x : camspeed.x;
        float newspeedy = Mathf.Abs(camspeed.y) > maxspeed ? maxspeed * y : camspeed.y;
        return new Vector2(newspeedx / 10f, newspeedy / 10f);
    }
}