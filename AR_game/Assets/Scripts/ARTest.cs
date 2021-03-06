using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARTest : MonoBehaviour
{
    [SerializeField]
    GameObject planeCube;//生成するオブジェクト
    private ARRaycastManager arRaycastManager;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();


    void Start()
    {
        arRaycastManager = GetComponent<ARRaycastManager>();
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)　　//画面に指が触れた時に処理する
            {
                if (arRaycastManager.Raycast(touch.position, hits, TrackableType.PlaneWithinPolygon))
                {
                    Pose hitPose = hits[0].pose;　　//RayとARPlaneが衝突しところのPose
                    Instantiate(planeCube, hitPose.position, hitPose.rotation);　　//オブジェクトの生成
                }
            }
        }
    }
}