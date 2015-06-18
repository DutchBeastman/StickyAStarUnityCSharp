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
            if(neighbourNodes.Contains(neighbour))
            {
                return ((Node)neighbour).cost;
            }

            return float.PositiveInfinity;
        }

        public float EstimatedCostTo(IAStarNode goal)
        {
            List<IAStarNode> ordered = new List<IAStarNode>(neighbourNodes);
            ordered.Sort((n1, n2) => (n1.CostTo(n2).CompareTo(n2.CostTo(n1))));
            for (int i = 0; i < ordered.Count; i++)
            {
                Debug.Log(ordered[i]);
            }
           
            /*List<IAStarNode> neighboursWalkable = new List<IAStarNode>();
            //loop through every neighbour of the tiles and find any path, here you use CostTo in a loop.
            for (int i = 0; i < neighbourNodes.Count; i++)
            {
                if(CostTo(neighbourNodes[i]) > 0)
                {
                    neighboursWalkable.Add(neighbourNodes[i]);
                    for (int j = 0; j < neighboursWalkable.Count; j++)
                    {
                        if(neighboursWalkable[j]
                    }
                }
                Debug.Log(CostTo(neighbourNodes[i]));
            }*/
            return cost;
        }

        public void AddNeighbour(IAStarNode neighbour)
        {
            neighbourNodes.Add(neighbour);
        }
    }
}
