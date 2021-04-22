using System.Collections;
using System.Collections.Generic;
using MiscUtil.Xml.Linq.Extensions;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform objectToFollow;
    public PlayerShipController player;
    public Camera camera;

    public float minCameraSize = 5.0f;
    public float maxCameraSize = 25.0f;

    void Update()
    {
        float lerpDist = player.rb.velocity.magnitude / player.maxLinearVelocity;
        camera.orthographicSize = Mathf.Lerp(minCameraSize, maxCameraSize, lerpDist);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(objectToFollow.position.x, objectToFollow.position.y, transform.position.z);
    }
}
