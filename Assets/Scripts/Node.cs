using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Pathing
{
    public class Node : MonoBehaviour, IAStarNode
    {
        private Vector2 nodePos;
        private List<IAStarNode> neighbourNodes = new List<IAStarNode>();
        [SerializeField] private int cost;

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


            if (neighbourNodes.Contains(neighbour) && cost > 0)
            {
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

                for (int j = 0; j < CostTo(ordered[i]); j++)
                {
                    if (CostTo(ordered[i]) > 0)
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
