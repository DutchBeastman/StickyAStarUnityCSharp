using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

namespace Pathing
{
    public class GameManager : MonoBehaviour
    {
        private List<Renderer> render = new List<Renderer>();
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
                    if (nodeComponent != null)
                    {
                        if (start != null && goal != null)
                        {

                            start = null;
                            goal = null;
                            for (int i = 0; i < render.Count; i++)
                            {
                                
                                render[i].material.color = Color.white;
                            }
                            render.Clear();
                        }
                        if (start == null)
                        {
                            goal = null;
                            start = hit.collider.GetComponent<Node>();
                        }
                        else if (goal == null && start != null)
                        {
                            goal = hit.collider.GetComponent<Node>();
                            IList<IAStarNode> pathNodes = AStar.GetPath(start, goal);
                            for (int i = 0; i < pathNodes.Count; i++)
                            {
                                if (pathNodes.Count != i)
                                {
                                    render.Add(((Node)pathNodes[i]).gameObject.transform.GetComponent<Renderer>());
                                    Debug.Log(((Node)pathNodes[i]).gameObject.transform.GetComponent<Renderer>());
                                    Debug.Log(render.Count);
                                    render[i].material.color = Color.red;
                                }

                            }
                        }

                    }
                }
              
            }

        }
    }
}