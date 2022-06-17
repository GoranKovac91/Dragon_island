using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateTerrain : MonoBehaviour
{
    [SerializeField] private int _width=256;
    [SerializeField] private int _height=500;
    [SerializeField] private int _depth=20;
    public float _offsetX  ;
    public float _offsetY  ;
    public float scale = 20;
    public int radius=10;
    public Vector3 TerrainCenter;
   
    private void Start()
    {
        Terrain terrain = GetComponent<Terrain>();
        terrain.terrainData = GenerateTerrainScale(terrain.terrainData);

    }


    TerrainData GenerateTerrainScale(TerrainData TerrainData)
    {
        TerrainData.heightmapResolution = _width + 1;
        TerrainData.size = new Vector3(_width, _depth, _height);
        TerrainCenter = TerrainData.bounds.center;
        int X = (int)TerrainCenter.x;
        int Z = (int)TerrainCenter.z;
       
        TerrainData.SetHeights(X,Z,GenerateHeights());
      
       
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
        float yCoord = (float) y / _height*scale;
      
        return Mathf.PerlinNoise(xCoord, yCoord);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(TerrainCenter, 20);
        
     
    }
  


}
