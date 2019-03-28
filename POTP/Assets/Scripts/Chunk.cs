using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//JacobBuoy 2019
//All game objects (prefabs) are called on top of the lanes prefabs
//This script spawns and despawns the prefabs in the lanes
public class Chunk : MonoBehaviour
{
    public GameObject prefabWall;
    public GameObject prefabPowerUp;
    public GameObject prefabPowerUp2;
    public GameObject prefabPowerUp3;
    public GameObject prefabBadGuy;
    // Start is called before the first frame update
    void Start()
    {
        SpawnSomethingAt("Spawn1");
        SpawnSomethingAt("Spawn2");
        SpawnSomethingAt("Spawn3");
    }
    private void SpawnSomethingAt(string name)
    {
        float ran = Random.value;
        if (ran < 0.2f)
        {
            SpawnWallAt(name);
        }
        else if (ran < .4f)
        {
            SpawnPowerUpAt(name);
        }
        else if (ran < .6f)
        {
            SpawnPowerUp2At(name);
        }
        else if (ran < .8f)
        {
            SpawnPowerUp3At(name);
        }
        else if (ran < 1f)
        {
            SpawnBadGuyAt(name);
        }
    }
    private void SpawnWallAt(string name)
    {   
        if(Random.Range(0, 100) < 60) // controls wall spawn rate
        {
            Vector3 position = transform.Find(name).position;
            GameObject obj = Instantiate(prefabWall, position, Quaternion.identity);
            SceneController.walls.Add(obj);
        }
    }
    private void SpawnBadGuyAt(string name) // controls bad guy spawn rate
    {
        if (Random.Range(0, 100) < 60)
        {
            Vector3 position = transform.Find(name).position;
            GameObject obj = Instantiate(prefabBadGuy, position, Quaternion.identity);
            SceneController.badguys.Add(obj);
        }
    }
    private void SpawnPowerUpAt(string name)
    {
        if (Random.Range(0, 100) < 40) // controls pwrup1 spawn rate
        {
            if (Random.Range(0, 100) < 70)
            {
                Vector3 position = transform.Find(name).position;
                GameObject obj = Instantiate(prefabPowerUp, position, Quaternion.identity);
                SceneController.powerups.Add(obj);
            }
            else
            {
                Vector3 position = transform.Find(name).position;
                position.y += 1; 
                GameObject obj = Instantiate(prefabPowerUp, position, Quaternion.identity);
                SceneController.powerups.Add(obj);
            }
        }
    }
    private void SpawnPowerUp2At(string name)
    {
        if (Random.Range(0, 100) < 20)// controls pwrup2 spawn rate
        {
            if (Random.Range(0, 100) < 70)
            {
                Vector3 position = transform.Find(name).position;
                GameObject obj = Instantiate(prefabPowerUp2, position, Quaternion.identity);
                SceneController.powerup2s.Add(obj);
            }
            else
            {
                Vector3 position = transform.Find(name).position;
                position.y += 1;
                GameObject obj = Instantiate(prefabPowerUp2, position, Quaternion.identity);
                SceneController.powerup2s.Add(obj);
            }
        }
    }
    private void SpawnPowerUp3At(string name)
    {
        if (Random.Range(0, 100) < 40)// controls pwrup3 spawn rate
        {
            if (Random.Range(0, 100) < 70)
            {
                Vector3 position = transform.Find(name).position;
                GameObject obj = Instantiate(prefabPowerUp3, position, Quaternion.identity);
                SceneController.powerup3s.Add(obj);
            }
            else
            {
                Vector3 position = transform.Find(name).position;
                position.y += 1;
                GameObject obj = Instantiate(prefabPowerUp3, position, Quaternion.identity);
                SceneController.powerup3s.Add(obj);
            }
        }
    }
}   

