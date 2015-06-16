using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

namespace Pathing
{
    public class Node : IAStarNode
    {

        /*private static List<IAStarNode> open = new List<IAStarNode>();

        [SerializeField]
        private int cost;
        public Node(int _cost, IAStarNode _aNode)
        {
                        
            cost = _cost;
        }*/
        

        public IEnumerable<IAStarNode> Neighbours
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public float CostTo(IAStarNode neighbour)
        {

            throw new NotImplementedException();
        }

        public float EstimatedCostTo(IAStarNode goal)
        {
            throw new NotImplementedException();
        }


    }
}
