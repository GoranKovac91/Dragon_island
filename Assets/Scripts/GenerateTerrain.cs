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
    Terrain terrain;
    public float octaves=4;
    public float lacunarity = 1;//1;
    public float persistance = 1; //pers 1;
   
   
    private void Awake()
    {
        _offsetX = Random.Range(-10000, 10000);
        _offsetY = Random.Range(-10000, 10000);
    }
    private void Start()
    {
        terrain = GetComponent<Terrain>();
        terrain.terrainData = GenerateTerrainScale(terrain.terrainData);
  
    }
   

    TerrainData GenerateTerrainScale(TerrainData TerrainData)
    {
        TerrainData.heightmapResolution = _width + 1;
        TerrainData.size = new Vector3 (_width, _depth, _height);
        TerrainCenter = TerrainData.bounds.center ;
        
        
        int X = (int)TerrainCenter.x;
        int Z = (int)TerrainCenter.z;
        
     
        TerrainData.SetHeights(X ,Z  , GenerateHeights() );  
        return TerrainData;
    }
    float[, ] GenerateHeights()
    {
        float maxNoise = float.MinValue;
        float MinNoise = float.MaxValue;
       

        float[,] heights = new float[_width, _height];
        for (int y = 0; y < _height ; y++)
        {
            for (int x= 0; x < _width; x++)
            {
                float noiseHeight =0;
                float frequency = 1;
                float amplitude = 1;
                for (int i = 0; i < octaves; i++)
                {
                    float sampleX = x / scale * frequency + _offsetX;
                    float sampleY = y / scale * frequency + _offsetY;
                    float perlinValue = Mathf.PerlinNoise(sampleX, sampleY) * 2 - 1;
                    noiseHeight += perlinValue * amplitude;
                    amplitude *= persistance;
                    frequency *= lacunarity;
                }
               
                if (noiseHeight>maxNoise)
                {
                    maxNoise = noiseHeight;
                }
                else if (noiseHeight<MinNoise)
                {
                    MinNoise = noiseHeight;
                }
                heights[x, y] = noiseHeight;

            }
        }
        for (int y = 0; y < _height; y++)
        {
            for (int x = 0; x < _width; x++)
           {
                heights[x, y] = Mathf.InverseLerp(MinNoise, maxNoise, heights[x, y]);
            }
        }

        return heights;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(TerrainCenter, 20);
        
     
    }
   
  


}
