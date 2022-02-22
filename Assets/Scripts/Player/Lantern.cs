using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lantern : MonoBehaviour
{
    public Camera cam;

    Vector2 mousePos;

    public Vector2 angles;

    public float offset;

    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        Vector2 lookDir = mousePos - (Vector2)transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg + offset;

        if (gameObject.name.Contains("Left"))
        {
            if (angles.x < angle || angle < angles.y)
            {
                transform.rotation = Quaternion.Euler(0f, 0f, angle);
            }
            else
            {
                var nearest = angles.x;
                var A = Mathf.Abs(Mathf.DeltaAngle(angle, angles.x));
                var B = Mathf.Abs(Mathf.DeltaAngle(angle, angles.y));
                if (A > B)
                {
                    nearest = angles.y;
                }
                transform.rotation = Quaternion.Euler(0f, 0f, nearest);
            }
        }
        else
        {
            if (angles.x < angle && angle < angles.y)
            {
                transform.rotation = Quaternion.Euler(0f, 0f, angle);
            }
            else
            {
                var nearest = angles.x;
                var A = Mathf.Abs(Mathf.DeltaAngle(angle, angles.x));
                var B = Mathf.Abs(Mathf.DeltaAngle(angle, angles.y));
                if (A > B)
                {
                    nearest = angles.y;
                }
                transform.rotation = Quaternion.Euler(0f, 0f, nearest);
            }
        }
    }
}
