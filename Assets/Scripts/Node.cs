using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Pathing
{
    public class Node : MonoBehaviour, IAStarNode
    {
        public Vector2 nodePos;
        public List<IAStarNode> neighbourNodes = new List<IAStarNode>();
        [SerializeField] public int cost;

        public Vector2 NodePos
        {
            get
            {
                return nodePos;
            }
            set
            {
                nodePos = value;
            }
        }
        public IEnumerable<IAStarNode> Neighbours
        {
            get
            {
                //Get all neighbours from tile
                return neighbourNodes;
            }
        }

        public float CostTo(IAStarNode neighbour)
        {

            
            if(neighbourNodes.Contains(neighbour) && cost > 0)
            {
                Debug.DrawLine(this.transform.position, ((Node)neighbour).transform.position, Color.blue, int.MaxValue);
                return ((Node)neighbour).cost;
            }

            return float.PositiveInfinity;
        }

        public float EstimatedCostTo(IAStarNode goal)
        {
   
            List<int> costs = new List<int>();
            List<IAStarNode> ordered = new List<IAStarNode>(neighbourNodes);
            ordered.Sort((n1, n2) => (n2.CostTo(n1).CompareTo(n1.CostTo(n2))));
            for (int i = 0; i < ordered.Count; i++)
            {
                Debug.DrawLine((ordered[i] as Node).transform.position, (goal as Node).transform.position, Color.red, int.MaxValue);
                if (CostTo(ordered[i]) > 0)
                {
                    for (int j = 0; j < CostTo(ordered[i]); j++)
                    { 
                        return (CostTo(neighbourNodes[j]));
                    }
                    
                }
            }
            return cost;
        }

        public void AddNeighbour(IAStarNode neighbour)
        {
            neighbourNodes.Add(neighbour);
        }
    }
}
