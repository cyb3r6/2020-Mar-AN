using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARTapToPlace : MonoBehaviour
{
    public GameObject tapToPlacePrefab;
    static List<ARRaycastHit> arHits = new List<ARRaycastHit>();
    private ARRaycastManager arRaycastManager;

    private Vector2 touchPosition;

    
    void Start()
    {
        arRaycastManager = GetComponent<ARRaycastManager>();
    }

    // need to know if we've touched our screen
    // and where!
    private bool TryGetTouchPosition(out Vector2 touchPosition)
    {
        if(Input.touchCount > 0)
        {
            touchPosition = Input.GetTouch(0).position;

            return true;
        }

        touchPosition = default;

        return false;
    }
    
    void Update()
    {
        if(!TryGetTouchPosition(out Vector2 touchPosition))
        {
            return;
        }

        if(arRaycastManager.Raycast(touchPosition, arHits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinPolygon))
        {
            var arHitPose = arHits[0].pose;

            GameObject spawnedObject = Instantiate(tapToPlacePrefab, arHitPose.position, arHitPose.rotation);
        }
    }
}
