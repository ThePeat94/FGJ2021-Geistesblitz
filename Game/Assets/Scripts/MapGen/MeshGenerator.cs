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
    public List<GameObject> PowerUps;

    Mesh mesh;

    List<Vector3> vertices = new List<Vector3>();
    List<int> triangles = new List<int>();
    List<GameObject> enemiesSpawned = new List<GameObject>();
    private List<GameObject> spawnedPowerups = new List<GameObject>();
    private LevelMap map;
    private ProdGen pg;
    private MapGen mg;
    
    private const float ONE_POWERUP_CHANCE = 0.25f;
    private const float TWO_POWERUPS_CHANCE = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        Generate();
    }

    // void OnValidate()
    // {        
    //     Generate();
    // }

    [ContextMenu("ProdGen/Generate")]
    private void Generate()
    {
        this.Seed = UnityEngine.Random.Range(int.MinValue, int.MaxValue);
        this.CleanSpawnedGameObjectList(this.enemiesSpawned);
        this.CleanSpawnedGameObjectList(this.spawnedPowerups);
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
                SpawnRandomPowerupsInRoom(r);
            }
        }

    }

    private void SpawnEnemy(int x, int y)
    {
        var en = pg.Select(Enemies);
        var inst = Instantiate(en);
        inst.transform.position = new Vector3(x * Scale, 1f, y * Scale);
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

    private void SpawnRandomPowerupsInRoom(Node room)
    {
        var chance = UnityEngine.Random.Range(0f, 1f);
        var amountToSpawn = 0;

        if (chance < TWO_POWERUPS_CHANCE)
            amountToSpawn = 1;
        else if (chance < ONE_POWERUP_CHANCE)
            amountToSpawn = 2;
        else
            return;

        var spawned = 0;

        while (spawned < amountToSpawn)
        {
            var rndPowerup = this.pg.Select(PowerUps);
            var rndX = UnityEngine.Random.Range(0, room.Quad.Width);
            var rndY = UnityEngine.Random.Range(0, room.Quad.Height);
            var spawnedGO = Instantiate(rndPowerup, new Vector3((room.Quad.X + rndX) * this.Scale, 1f, (room.Quad.Y + rndY) * this.Scale), Quaternion.identity);            
            spawned++;
            this.spawnedPowerups.Add(spawnedGO);
        }

    }

    private void CleanSpawnedGameObjectList(List<GameObject> list)
    {
        foreach (var gameObject in list)
        {
            DestroyImmediate(gameObject);
        }
        list.Clear();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
