using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//JacobBuoy 2019
//This script is in charge of prefabs that get destoryed from the chunk script
public class SceneController : MonoBehaviour
{
    public GameObject prefabChunk;
    public Transform player;
    public bool extraJump = false;
    List<GameObject> chunks = new List<GameObject>();
    static public List<GameObject> walls = new List<GameObject>();
    static public List<GameObject> badguys = new List<GameObject>();
    static public List<GameObject> powerups = new List<GameObject>();
    static public List<GameObject> powerup2s = new List<GameObject>();
    static public List<GameObject> powerup3s = new List<GameObject>();
    static public List<GameObject> bullets = new List<GameObject>();
    ColliderAABB pBox;
    PlayerRun playerRef;
    // Startis called before the first frame update
    void Start()
    {
        pBox = GameObject.Find("Player").GetComponent<ColliderAABB>();
        playerRef = GameObject.Find("Player").GetComponent<PlayerRun>();
    }
    // Update is called once per frame
    void Update()
    {
        if (!playerRef.gameHasStarted)
        {
            if (chunks.Count > 0)
            {
                Destroy(chunks[0]);
                chunks.RemoveAt(0);
            }
            if (walls.Count > 0)
            {
                Destroy(walls[0]);
                walls.RemoveAt(0);
            }
            if (badguys.Count > 0)
            {
                Destroy(badguys[0]);
                badguys.RemoveAt(0);
            }
            if (powerups.Count > 0)
            {

                Destroy(powerups[0]);
                powerups.RemoveAt(0);
            }
            if (powerup2s.Count > 0)
            {
                Destroy(powerup2s[0]);
                powerup2s.RemoveAt(0);
            }
            if (powerup3s.Count > 0)
            {

                Destroy(powerup3s[0]);
                powerup3s.RemoveAt(0);
            }
            if (bullets.Count > 0)
            {

                Destroy(bullets[0]);
                bullets.RemoveAt(0);
            }
        }
        foreach (GameObject badGuy in badguys) //makes the bad guys run
        {
            if (badGuy == null) continue;
            badGuy.transform.position -= new Vector3(0, 0, .1f);
        }
        if (chunks.Count > 0)
        {
            if (chunks[0] == null) return;
            if (player.position.z - chunks[0].transform.position.z > 27)
            {
                Destroy(chunks[0]);
                chunks.RemoveAt(0);

            }
        }
        if (walls.Count > 0)
        {
            if (walls[0] == null) return;
            if (player.position.z - walls[0].transform.position.z > 27)
            {
                Destroy(walls[0]);
                walls.RemoveAt(0);
            }
        }
        if (badguys.Count > 0)
        {
            if (badguys[0] == null) return;
            if (player.position.z - badguys[0].transform.position.z > 27)
            {
                Destroy(badguys[0]);
                badguys.RemoveAt(0);
            }
        }
        if (powerups.Count > 0)
        {
            if (powerups[0] == null) return;
            if (player.position.z - powerups[0].transform.position.z > 27)
            {
                Destroy(powerups[0]);
                powerups.RemoveAt(0);
            }
        }
        if (powerup2s.Count > 0)
        {
            if (powerup2s[0] == null) return;
            if (player.position.z - powerup2s[0].transform.position.z > 27)
            {
                Destroy(powerup2s[0]);
                powerup2s.RemoveAt(0);

            }
        }
        if (powerup3s.Count > 0)
        {
            if (powerup3s[0] == null) return;
            if (player.position.z - powerup3s[0].transform.position.z > 27)
            {
                Destroy(powerup3s[0]);
                powerup3s.RemoveAt(0);

            }
        }
        if (bullets.Count > 0)
        {
            if (bullets[0] == null) return;
            if (bullets[0].transform.position.z - player.position.z > 40)
            {
                Destroy(bullets[0]);
                bullets.RemoveAt(0);

            }
        }
        while (chunks.Count < 15 && playerRef.gameHasStarted)
        {
            // spawn a new chunk
            Vector3 position = Vector3.zero;
            if (chunks.Count > 0)
            {
                position = chunks[chunks.Count - 1].transform.Find("Connector").position;
            }
            GameObject obj = Instantiate(prefabChunk, position, Quaternion.identity);
            chunks.Add(obj);
        }

        if (walls.Count > 0)
        {
            for (int i = 0; i < walls.Count; i++)
            {
                if (pBox.CheckOverlap(walls[i].GetComponent<ColliderAABB>()))
                {
                    if (playerRef.karma <= .3f)
                    {
                        playerRef.hp--;
                    }
                    else if (playerRef.karma >= .7f)
                    {
                        playerRef.hp -= 3;
                    }
                    else
                    {
                        playerRef.hp -= 2;
                    }
                    Destroy(walls[i]);
                    walls.RemoveAt(i);
                }
            }
        }

        if (badguys.Count > 0)
        {
            for (int i = 0; i < badguys.Count; i++)
            {

                if (pBox.CheckOverlap(badguys[i].GetComponent<ColliderAABB>()))
                {

                    if (playerRef.isAttacking)
                    {
                        playerRef.killed = true;
                        playerRef.karma -= .15f;
                    }
                    else if (playerRef.karma <= .3f && !playerRef.isAttacking)
                    {
                        playerRef.hp--;
                    }
                    else if (playerRef.karma >= .7f && !playerRef.isAttacking)
                    {
                        playerRef.hp -= 3;
                    }
                    else if (!playerRef.isAttacking)
                    {
                        playerRef.hp -= 2;
                    }
                    Destroy(badguys[i]);
                    badguys.RemoveAt(i);
                }
            }
        }
        if (powerups.Count > 0)
        {
            for (int i = 0; i < powerups.Count; i++)
            {
                if (pBox.CheckOverlap(powerups[i].GetComponent<ColliderAABB>()))
                {
                    playerRef.karma += .15f;
                    Destroy(powerups[i]);
                    powerups.RemoveAt(i);
                }
            }
        }
        if (powerup2s.Count > 0)
        {
            for (int i = 0; i < powerup2s.Count; i++)
            {
                if (pBox.CheckOverlap(powerup2s[i].GetComponent<ColliderAABB>()))
                {
                    if (playerRef.hp < 6)
                    {
                        playerRef.hp++;
                    }
                    Destroy(powerup2s[i]);
                    powerup2s.RemoveAt(i);
                }
            }
        }
        if (powerup3s.Count > 0)
        {
            for (int i = 0; i < powerup3s.Count; i++)
            {
                if (pBox.CheckOverlap(powerup3s[i].GetComponent<ColliderAABB>()))
                {
                    playerRef.karma -= .15f;
                    Destroy(powerup3s[i]);
                    powerup3s.RemoveAt(i);
                }
            }
        }
        if (bullets.Count > 0)
        {
            for (int i = 0; i < bullets.Count; i++)
            {
                float tempZ = bullets[i].transform.localPosition.z;
                tempZ += 1;
                for (int z = 0; z <  walls.Count; z++)
                {
                    if (walls[z].GetComponent<ColliderAABB>().CheckOverlap(bullets[i].GetComponent<ColliderAABB>()))
                    {
                        Destroy(bullets[i]);
                        bullets.RemoveAt(i);
                        Destroy(walls[z]);
                        walls.RemoveAt(z);
                    }
                }

            }
        }
    }
}