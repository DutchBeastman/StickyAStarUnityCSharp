using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

namespace Pathing
{
    public class GameManager : MonoBehaviour
    {
        private Node start;
        private Node goal;

        protected void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {                
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    Node nodeComponent = hit.collider.GetComponent<Node>();

                    if (nodeComponent == null)
                    {
                        return;
                    }
                    else
                    {
                      Vector2 collidingPos =  hit.collider.GetComponent<Node>().NodePos;
                        Debug.Log(collidingPos);
                    }

                    if (start == null)
                    {
                        start = hit.collider.GetComponent<Node>();
                        Debug.Log("Start == " + start);
                    }
                    else if (goal == null && start != null)
                    {
                        goal = hit.collider.GetComponent<Node>();
                        //AStar.GetPath(start, goal);
                        Debug.DrawLine(start.transform.position, goal.transform.position);
                        Debug.Log("Goal == " + goal);
                    }

                }
            }

        }
    }
}