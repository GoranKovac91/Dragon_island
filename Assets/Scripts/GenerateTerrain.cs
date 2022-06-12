using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateTerrain : MonoBehaviour
{
    private Mesh _mesh;
    [SerializeField] private Vector3[] _vertices;
    [SerializeField] private int[] _triangles;
    [SerializeField] private int _xSize = 500;
    [SerializeField] private int _zSize = 500;
    private void Awake()
    {
        _mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = _mesh;
        CreateShape();
        UpdateMesh();
    }
    public void CreateShape()
    {
        _vertices = new Vector3[(_xSize + 1) * (_zSize + 1)];
        
        for (int i = 0, z = 0; z <= _zSize; z++)
        {
            for (int x = 0; x <= _xSize; x++)
            {
                float y = Mathf.PerlinNoise(x*.5f, z*.5f) * 2;
                _vertices[i] = new Vector3(x, y, z);
                i++;
            }
        }
        _triangles = new int[_xSize * _zSize * 6];
        int vert = 0;
        int tris = 0;
        for (int z = 0; z < _zSize; z++)
        {
            for (int x = 0; x < _xSize; x++)
            {

                _triangles[tris + 0] = vert + 0;
                _triangles[tris + 1] = vert + _xSize + 1;
                _triangles[tris + 2] = vert + 1;
                _triangles[tris + 3] = vert + 1;
                _triangles[tris + 4] = vert + _xSize + 1;
                _triangles[tris + 5] = vert + _xSize + 2;
                vert++;
                tris += 6;
            }
            vert++;
        }
       
    }
    public void UpdateMesh()
    {
        _mesh.Clear();
        _mesh.vertices = _vertices;
        _mesh.triangles = _triangles;
        _mesh.RecalculateNormals();
    }
}
