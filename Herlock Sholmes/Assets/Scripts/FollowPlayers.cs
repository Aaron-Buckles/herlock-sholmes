using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class FollowPlayers : MonoBehaviour {

    public Transform[] players;
    public float movementSmoothness = 0.5f;
    public float zoomSmoothness = 0.5f;
    public float cameraPadding = 1f;
    public float maxZoom = 5f;
    public float minZoom = 30f;

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
        Vector3 midpoint = Midpoint( players[0], players[1] );
        cam.transform.position = Vector3.SmoothDamp( cam.transform.position, midpoint, ref velocity, movementSmoothness );
    }

    Vector3 Midpoint(Transform pos1, Transform pos2)
    {
        float midX = ( pos1.position.x + pos2.position.x ) / 2;
        float midY = ( pos1.position.y + pos2.position.y ) / 2;
        return new Vector3( midX, midY, cam.transform.position.z );
    }

    void Zoom()
    {
        float distance = Distance( players[0], players[1] );
        float value = ( distance / 1.5f ) + cameraPadding;

        float zoomLevel = Mathf.Clamp( value, maxZoom, minZoom );
        cam.orthographicSize = Mathf.Lerp( cam.orthographicSize, zoomLevel, zoomSmoothness );
    }

    float Distance( Transform pos1, Transform pos2 )
    {
        float xDiff = pos2.position.x - pos1.position.x;
        float yDiff = pos2.position.y - pos1.position.y;

        return Mathf.Sqrt( Mathf.Pow(xDiff, 2) + Mathf.Pow(yDiff, 2) );
    }

}
