using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Pathing;


public class Generator : MonoBehaviour {
    //public enum Tiles { Grass, Mountain, Forest, Desert, Water};


    [SerializeField]private List<Node> nodes;
    [SerializeField]private GameObject [] tiles; 
    [SerializeField]private int tilesX;
    [SerializeField]private int tilesZ;
	// Use this for initialization
	protected void Start () {
        //Tiles tiles = (Tiles)UnityEngine.Random.Range(0, Enum.GetValues(typeof(Tiles)).Length);
        //Generation();
        Generation();
	}
    private void Generation()
    {
        
        for (int x = 0; x < tilesX; x++)
        {

            Vector3 position = Vector3.right * x;

            for (int z = 0; z < tilesZ; z++)
            {

                position -= Vector3.forward / 1.4f;

                if ((z % 2) == 0)
                {
                    position -= Vector3.right / 2;
                }
                else
                {
                    position += Vector3.right / 2;
                }

                //position -= Vector3.forward * 3/4;
                GameObject instantiateNode = (GameObject)Instantiate(tiles[Random.Range(0, tiles.Length)], position, Quaternion.identity);
                Node node = instantiateNode.GetComponent<Node>();
                node.NodePos = new Vector2(x, z);
                nodes.Add(node);
                DetermineNeighbours(node);

               


            }
        }
        SetNeighbours();
    }

    private void SetNeighbours()
    {


    }
    //checking for neighbours
    private void DetermineNeighbours(Node current)
    {
        List<Vector2> vector2List = new List<Vector2>();
        vector2List.Add(new Vector2(0, -1));
        vector2List.Add(new Vector2(+1, -1));
        vector2List.Add(new Vector2(+1, 0));
        vector2List.Add(new Vector2(0, +1));
        vector2List.Add(new Vector2(-1, +1));
        vector2List.Add(new Vector2(-1, 0));

        for (int i = 0; i < nodes.Count; i++)
        {
            for (int j = 0; j < vector2List.Count; j++)
            {
                Vector2 adjustedCurrent = current.NodePos;
                adjustedCurrent += vector2List[j];
                if(nodes[i].NodePos == adjustedCurrent)
                {
                    //here the neigbours will add each other and give that through to the other node so that all nodes will have the correct amount of neighbours
                    current.AddNeighbour(nodes[i]);
                    nodes[i].AddNeighbour(current);

                }
            }
        }
    }



	
}
