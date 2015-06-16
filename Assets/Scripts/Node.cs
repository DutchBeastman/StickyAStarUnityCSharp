using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

namespace Pathing
{
    public class Node : MonoBehaviour, IAStarNode
    {
        [SerializeField] private Node [] neighbourNodes;
        [SerializeField] private int cost;

        public IEnumerable<IAStarNode> Neighbours
        {
            get
            {
                //Get all neighbours from tile
                
                throw new NotImplementedException();
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

            throw new NotImplementedException();
        }
    }
}
