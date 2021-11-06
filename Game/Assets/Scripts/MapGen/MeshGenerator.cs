using net6test.MapGenerator;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.AI.Navigation;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshCollider))]
public class MeshGenerator : MonoBehaviour
{
    public int Seed = 1986;
    public int Width = 64;
    public int Height = 64;
    public int Threshold = 6;

    Mesh mesh;

    List<Vector3> vertices = new List<Vector3>();
    List<int> triangles = new List<int>();
    private LevelMap map;

    // Start is called before the first frame update
    void Start()
    {
        Generate();
    }

    void OnValidate()
    {
        Generate();
    }

    private void Generate()
    {
        vertices.Clear();
        triangles.Clear();

        var pg = new ProdGen(Seed);
        var mg = new MapGen(pg, Width, Height, Threshold);
        this.map = mg.Map;

        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        CreateShape();
        UpdateMesh();
        GetComponent<NavMeshSurface>().BuildNavMesh();

    }

    private void UpdateMesh()
    {
        mesh.Clear();
                
        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles.ToArray();
        mesh.RecalculateNormals();
        GetComponent<MeshCollider>().sharedMesh = mesh;
    }

    private void CreateShape()
    {
        map.ForEachXY((x,y,v) =>
        {
            if(v != LevelElement.Wall)
            {
                var last = vertices.Count;

                vertices.Add(new Vector3(x, 0, y));
                vertices.Add(new Vector3(x, 0, y+1));
                vertices.Add(new Vector3(x+1, 0, y));
                vertices.Add(new Vector3(x+1, 0, y+1));

                triangles.Add(last);
                triangles.Add(last+1);
                triangles.Add(last+2);
                triangles.Add(last+1);
                triangles.Add(last+3);
                triangles.Add(last+2);
            }

            
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
