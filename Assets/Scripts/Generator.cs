using UnityEngine;
using System.Collections;
using System;

public class Generator : MonoBehaviour {
    public enum Tiles { Grass, Mountain, Forest, Desert, Water};

    
    [SerializeField]private int tilesX;
    [SerializeField]private int tilesY;
	// Use this for initialization
	protected void Start () {
        Tiles tiles = (Tiles)UnityEngine.Random.Range(0, Enum.GetValues(typeof(Tiles)).Length);
	}
    private void Generation()
    {
        for (int i = 0; i < tilesX; i++)
        {
            Tiles tiles = (Tiles)UnityEngine.Random.Range(0, Enum.GetValues(typeof(Tiles)).Length);
            

        }

    }
	
	// Update is called once per frame
	protected void Update () {
	
	}
}
