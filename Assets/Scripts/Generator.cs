using UnityEngine;
using System.Collections;



public class Generator : MonoBehaviour {
    //public enum Tiles { Grass, Mountain, Forest, Desert, Water};

    [SerializeField]private GameObject [] tiles; 
    [SerializeField]private int tilesX;
    [SerializeField]private int tilesY;
	// Use this for initialization
	protected void Start () {
        //Tiles tiles = (Tiles)UnityEngine.Random.Range(0, Enum.GetValues(typeof(Tiles)).Length);
        Generation();
	}
    private void Generation()
    {
        for (int x = 0; x < tilesX; x++)
        {

            Vector3 position = Vector3.right * x;

            for (int z = 0; z < tilesY; z++)
            {
                position += Vector3.forward / 1.4f;

                if ((z % 2) == 0)
                {
                    position += Vector3.right / 2;
                }
                else
                {
                    position -= Vector3.right / 2;
                }

                //position -= Vector3.forward * 3/4;
                Instantiate(tiles[Random.Range(0, tiles.Length)], position, Quaternion.identity);                
            }
        }

    }
	
	// Update is called once per frame
	protected void Update () {
	
	}
}
