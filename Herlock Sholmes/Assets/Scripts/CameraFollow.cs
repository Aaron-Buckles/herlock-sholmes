using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraFollow : MonoBehaviour
{

    public Transform[] players;
    public float smoothness;
    public int maxZoom;
    public int minZoom;

    Camera cam;
    Vector3 velocity;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void FixedUpdate()
    {
        Move();
        Zoom();
    }

    void Move()
    {
        Vector3 midpoint = Midpoint(players[0], players[1]);
        cam.transform.position = Vector3.SmoothDamp(cam.transform.position, midpoint, ref velocity, smoothness);
    }

    void Zoom()
    {
        float distance = Distance(players[0], players[1]);
        float zoomLevel = Mathf.Clamp((distance / 2) + 1, maxZoom, minZoom);
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, zoomLevel, smoothness);
    }

    Vector3 Midpoint(Transform pos1, Transform pos2)
    {
        float midX = (pos1.position.x + pos2.position.x) / 2;
        float midY = (pos1.position.y + pos2.position.y) / 2;
        return new Vector3(midX, midY, cam.transform.position.z);
    }

    float Distance(Transform pos1, Transform pos2)
    {
        float xDiff = pos2.position.x - pos1.position.x;
        float yDiff = pos2.position.y - pos1.position.y;

        return Mathf.Sqrt(Mathf.Pow(xDiff, 2) + Mathf.Pow(yDiff, 2));
    }

}
