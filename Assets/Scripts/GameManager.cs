using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

namespace Pathing
{
    public class GameManager : MonoBehaviour
    {
        private IAStarNode start, goal;


        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {

                Ray ray;
                RaycastHit hit;
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray,out hit))
                {
                    if (hit.transform.tag == "Node" && start == null)
                    {
                        start = (IAStarNode) GetComponent(typeof(IAStarNode));
                        Debug.Log("Start == " + start);
                    }
                    if (hit.transform.tag == "Node" && goal == null && start != null)
                    {
                        goal = (IAStarNode)GetComponent(typeof(IAStarNode));
                        Debug.Log("Goal == " + goal);
                    }
                }
            }

        }
    }
}