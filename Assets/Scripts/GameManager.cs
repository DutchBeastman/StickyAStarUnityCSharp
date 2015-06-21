﻿using UnityEngine;
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
            //Making sure you can set a Waypoint through mouse click
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
                    }

                    if (start == null)
                    {
                        start = hit.collider.GetComponent<Node>();
                    }
                    else if (goal == null && start != null)
                    {
                        goal = hit.collider.GetComponent<Node>();
                        AStar.GetPath(start, goal);
                        Debug.DrawLine(start.transform.position, goal.transform.position,Color.yellow, int.MaxValue);
              
                    }

                }
            }

        }
    }
}