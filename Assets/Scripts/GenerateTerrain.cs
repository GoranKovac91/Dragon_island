using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateTerrain : MonoBehaviour
{
    [SerializeField] private int _width=256;
    [SerializeField] private int _height=500;
    [SerializeField] private int _depth=20;
     public float _offsetX = 100f;
     public float _offsetY = 100f;
     public float scale = 20;
    private void Start()
    {
        Terrain terrain = GetComponent<Terrain>();
        terrain.terrainData = GenerateTerrainScale(terrain.terrainData);
    }
  
    TerrainData GenerateTerrainScale(TerrainData TerrainData)
    {
        TerrainData.heightmapResolution = _width + 1;
        TerrainData.size = new Vector3(_width, _depth, _height);
        TerrainData.SetHeights(0, 0, GenerateHeights());
        return TerrainData;
    }
    float[,] GenerateHeights()
    {
        float[,] heights = new float[_width, _height];
        for (int x = 0; x <_width ; x++)
        {
            for (int y = 0; y < _height; y++)
            {
                heights[x, y] = CalculateHeight(x, y);
            }
        }
        return heights;
    }
    float CalculateHeight(int x,int y)
    {
        float xCoord = (float) x / _width*scale  ;
        float yCoord = (float) y / _height*scale  ;
        return Mathf.PerlinNoise(xCoord, yCoord);
    }

}
