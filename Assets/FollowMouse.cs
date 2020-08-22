using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    bool mousedown = false;

    // Update is called once per frame
    void Update()
    {
        this.transform.position = Vector3.Scale(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.up + Vector3.right);
        var old = mousedown;
        mousedown = Input.GetMouseButton(0);
        if (mousedown != old)
        {
            var hits = Physics2D.RaycastAll(transform.position, Vector2.left + Vector2.up, transform.localScale.magnitude);
            Debug.DrawRay(transform.position, (Vector2.left + Vector2.up) * transform.localScale.magnitude, Color.red, 2);
            onClick handler;
            foreach (var hit in hits)
                if (hit && (handler = hit.collider.GetComponent<onClick>()) != null)
                    if (mousedown)
                    {
                        handler.Click(transform);
                    }
                    else
                    {
                        handler.ClickRelease(transform);
                    }
        }
    }
}
