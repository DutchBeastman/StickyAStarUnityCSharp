using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Pathing;


public class Generator : MonoBehaviour {
    //public enum Tiles { Grass, Mountain, Forest, Desert, Water};

    [SerializeField]private List<Vector2> nodeCoordinates;
    [SerializeField]private List<Node> nodes;
    [SerializeField]private GameObject [] tiles; 
    [SerializeField]private int tilesX;
    [SerializeField]private int tilesZ;
	// Use this for initialization
	protected void Start () {
        //Tiles tiles = (Tiles)UnityEngine.Random.Range(0, Enum.GetValues(typeof(Tiles)).Length);
        //Generation();
        StartCoroutine(Generation());
	}
    private IEnumerator Generation()
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
                nodeCoordinates.Add(node.NodePos);
                Debug.Log(node.NodePos);
                //neighbours toevoegen 
                if (x == tilesX - 1 && z == tilesZ - 1)
                {
                    Debug.Log("kaaseNAppelszijngoed");
                }
                yield return new WaitForSeconds(0.1f);


            }
        }
        
    }

    //Checking for the neighbours
    private List<Node> CheckingNeighbours(Node current) 
    {
        
        return nodes;
    }

    private void NodeLooping()
    {
        for (int i = 0; i < nodes.Count; i++)
        {
            

        }
   
    }
	
}
