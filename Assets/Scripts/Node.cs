using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

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
            //Get every cost from every neighbour
            
            throw new NotImplementedException();
        }

        public float EstimatedCostTo(IAStarNode goal)
        {
            //loop through every neighbour of the tiles and find any path, here you use CostTo in a loop.
            for (int i = 0; i < neighbourNodes.Count; i++)
            {
                CostTo(neighbourNodes[i]);
            }

            throw new NotImplementedException();
        }

        public void AddNeighbour(IAStarNode neighbour)
        {
            
            neighbourNodes.Add(neighbour);
        }
    }
}
