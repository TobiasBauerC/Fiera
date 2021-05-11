using System.Collections;
using System.Collections.Generic;
using MiscUtil.Xml.Linq.Extensions;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private SpaceManager spaceManager;
    [SerializeField] private  Camera camera;
    [Space] 
    [SerializeField] private float cameraMoveSpeed = 10.0f;
    [Space]
    [SerializeField] private  float zoomSpeed = 10.0f;

    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerShipController ship = spaceManager.activeShip;
        
        MoveCamera(ship.transform);
        SetCameraZoom(ship);
    }

    void MoveCamera(Transform target)
    {
        Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
        float distToTargetPos = Vector3.Distance(transform.position, targetPosition);
        if (distToTargetPos > 0.01f)
            transform.position = Vector3.Lerp(transform.position, targetPosition, cameraMoveSpeed * Time.deltaTime);
    }

    void SetCameraZoom(PlayerShipController ship)
    {
        float lerpDist = ship.savedVelocity / ship.maxLinearVelocity;
        Debug.Log(ship.savedVelocity);
        float targetCameraSize = Mathf.Lerp(ship.minCameraSize, ship.maxCameraSize, lerpDist);
        float distToTargetCameraSize = Mathf.Abs(camera.orthographicSize - targetCameraSize);
        if (distToTargetCameraSize > 0.01f)
            camera.orthographicSize = Mathf.Lerp(camera.orthographicSize, targetCameraSize, zoomSpeed * Time.deltaTime);
    }
}
