using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{
    public LayerMask navigable; //ground plane
    public LayerMask interact; //ingame objects
    public Camera overheadCam;

    private NavMeshAgent playerAgent;
    private Ray clickRay;
    //private Camera cam;

    void Start()
    {
        playerAgent = GetComponent<NavMeshAgent>();
    }

    void OnGUI()
    {
        if (Input.GetMouseButtonDown(1))
        {
            //shoots ray from camera towards mouseclick
            clickRay = overheadCam.ScreenPointToRay(Input.mousePosition);
            //point of collision from camera raycast
            RaycastHit hitInfo;

            //if ray collides with floor...
            if (Physics.Raycast(clickRay, out hitInfo, 150, navigable))
            {
                //...tell player to move to that point
                playerAgent.SetDestination(hitInfo.point);
            }
            //if ray collides with object...
            if (Physics.Raycast(clickRay, out hitInfo, 150, interact))
            {
                //...player moves near object
            }
        }
    }
}
