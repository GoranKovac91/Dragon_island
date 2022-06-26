using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GenerateTexture : MonoBehaviour
{
   
    public Terrain terrain;
  
       
 
    void Start()
    {
        float[,,] map = new float[terrain.terrainData.alphamapWidth, terrain.terrainData.alphamapHeight, 3];
        float[,] heights = terrain.terrainData.GetHeights(0, 0, terrain.terrainData.alphamapWidth, terrain.terrainData.alphamapHeight);

      
        for (int y = 0; y < terrain.terrainData.alphamapHeight; y++)
        {
            for (int x = 0; x < terrain.terrainData.alphamapWidth; x++)
            {
               
                float normX = x * 1.0f / (terrain.terrainData.alphamapWidth - 1);
                float normY = y * 1.0f / (terrain.terrainData.alphamapHeight - 1);
                var angle = terrain.terrainData.GetSteepness(normX, normY);
            


                var frac = angle / 90.0;
                if (heights[x, y] > 0.7f  )
                {
                    map[x, y, 2] =  (float)(2- frac);
                }
                else if ( heights[x, y] < 0.7f && heights[y, x] > 0.6f)
                {
                  
                    map[x, y, 1] = (float) (1- frac) ;
                }
                else 
                {
                    map[x, y, 0] = (float)frac;
                }
                
               
               
            }
        }
        terrain.terrainData.SetAlphamaps(0, 0, map);
    }
}

 
    

