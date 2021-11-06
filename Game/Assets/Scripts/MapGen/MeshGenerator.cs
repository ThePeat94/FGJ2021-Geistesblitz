using net6test.MapGenerator;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.AI.Navigation;
using System.Linq;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshCollider))]
public class MeshGenerator : MonoBehaviour
{
    public int Seed = 1986;
    public int Width = 64;
    public int Height = 64;
    public int Threshold = 6;
    public float Scale = 2;
    public GameObject Player;
    public List<GameObject> Enemies;

    Mesh mesh;

    List<Vector3> vertices = new List<Vector3>();
    List<int> triangles = new List<int>();
    List<GameObject> enemiesSpawned = new List<GameObject>();
    private LevelMap map;
    private ProdGen pg;
    private MapGen mg;

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
        enemiesSpawned.ForEach(x => DestroyImmediate(x));
        enemiesSpawned.Clear();
        vertices.Clear();
        triangles.Clear();

        pg = new ProdGen(Seed);
        mg = new MapGen(pg, Width, Height, Threshold);
        this.map = mg.Map;

        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        CreateShape();
        UpdateMesh();
        GetComponent<NavMeshSurface>().BuildNavMesh();

        if (Player != null)
        {
            var c = mg.StartRoom.Center();
            Player.transform.position = new Vector3(c.X * Scale, 0, c.Y * Scale);
        }

        if(Enemies.Count > 0)
        {
            foreach (var r in mg.Rooms.Where(x => x.IsEnabled))
            {
                if (r == mg.StartRoom) continue;

                var c = r.Center();
                SpawnEnemy(c.X, c.Y);
                
                //var el = map[c.X, c.Y];
                //var sg = map.SubGrid(r.Quad.X, r.Quad.Y, r.Quad.Width, r.Quad.Height);
                
            }
        }

    }

    private void SpawnEnemy(int x, int y)
    {
        var en = pg.Select(Enemies);
        var inst = Instantiate(en);
        inst.transform.position = new Vector3(x * Scale, 0, y * Scale);
        enemiesSpawned.Add(inst);
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
                AddFloor(x, y);
                var n = map.Neighbours(x, y);
                if (n[0] == LevelElement.Wall) AddWallE(x, y);
                if (n[1] == LevelElement.Wall) AddWallW(x, y);
                if (n[2] == LevelElement.Wall) AddWallN(x, y);
                if (n[3] == LevelElement.Wall) AddWallS(x, y);
            } else
            {
                AddCap(x,y);
            }         
        });
    }

    private void AddWallE(int x, int y)
    {
        x *= (int)Scale;
        y *= (int)Scale;

        var last = vertices.Count;
        vertices.Add(new Vector3(x + Scale, Scale, y));
        vertices.Add(new Vector3(x + Scale, Scale, y + Scale));
        vertices.Add(new Vector3(x + Scale, 0, y));
        vertices.Add(new Vector3(x + Scale, 0, y + Scale));

        triangles.Add(last);
        triangles.Add(last + 2);
        triangles.Add(last + 1);
        triangles.Add(last + 1);
        triangles.Add(last + 2);
        triangles.Add(last + 3);
    }

    private void AddWallW(int x, int y)
    {
        x *= (int)Scale;
        y *= (int)Scale;

        var last = vertices.Count;
        vertices.Add(new Vector3(x, Scale, y));
        vertices.Add(new Vector3(x, Scale, y + Scale));
        vertices.Add(new Vector3(x, 0, y));
        vertices.Add(new Vector3(x, 0, y + Scale));

        triangles.Add(last);
        triangles.Add(last + 1);
        triangles.Add(last + 2);
        triangles.Add(last + 1);
        triangles.Add(last + 3);
        triangles.Add(last + 2);
    }

    private void AddWallN(int x, int y)
    {
        x *= (int)Scale;
        y *= (int)Scale;

        var last = vertices.Count;
        vertices.Add(new Vector3(x, Scale, y));
        vertices.Add(new Vector3(x + Scale, Scale, y));
        vertices.Add(new Vector3(x, 0, y));
        vertices.Add(new Vector3(x+Scale, 0, y));

        triangles.Add(last);
        triangles.Add(last + 2);
        triangles.Add(last + 1);
        triangles.Add(last + 1);
        triangles.Add(last + 2);
        triangles.Add(last + 3);
    }

    private void AddWallS(int x, int y)
    {
        x *= (int)Scale;
        y *= (int)Scale;

        var last = vertices.Count;
        vertices.Add(new Vector3(x, Scale, y+Scale));
        vertices.Add(new Vector3(x + Scale, Scale, y+Scale));
        vertices.Add(new Vector3(x, 0, y+Scale));
        vertices.Add(new Vector3(x + Scale, 0, y+Scale));

        triangles.Add(last);
        triangles.Add(last + 1);
        triangles.Add(last + 2);
        triangles.Add(last + 1);
        triangles.Add(last + 3);
        triangles.Add(last + 2);
    }

    private void AddFloor(int x, int y)
    {
        x *= (int)Scale;
        y *= (int)Scale;

        var last = vertices.Count;

        vertices.Add(new Vector3(x, 0, y));
        vertices.Add(new Vector3(x, 0, y + Scale));
        vertices.Add(new Vector3(x + Scale, 0, y));
        vertices.Add(new Vector3(x + Scale, 0, y + Scale));

        triangles.Add(last);
        triangles.Add(last + 1);
        triangles.Add(last + 2);
        triangles.Add(last + 1);
        triangles.Add(last + 3);
        triangles.Add(last + 2);
    }

    private void AddCap(int x, int y)
    {
        x *= (int)Scale;
        y *= (int)Scale;

        var last = vertices.Count;

        vertices.Add(new Vector3(x, Scale, y));
        vertices.Add(new Vector3(x, Scale, y + Scale));
        vertices.Add(new Vector3(x + Scale, Scale, y));
        vertices.Add(new Vector3(x + Scale, Scale, y + Scale));

        triangles.Add(last);
        triangles.Add(last + 1);
        triangles.Add(last + 2);
        triangles.Add(last + 1);
        triangles.Add(last + 3);
        triangles.Add(last + 2);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
