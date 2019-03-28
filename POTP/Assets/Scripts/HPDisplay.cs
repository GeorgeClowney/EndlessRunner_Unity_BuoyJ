using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HPDisplay : MonoBehaviour
//JacobBuoy 2019
//This is the script that controls all the hud elements in the game
{
    PlayerRun playerRef;
    public Text SCORE;
    public Image One;
    public Image Two;
    public Image Three;
    public Image Four;
    public Image Five;
    public Image Six;
    public Slider karmabar;
    // Start is called before the first frame update
    void Start()
    {
        playerRef = GameObject.Find("Player").GetComponent<PlayerRun>();
        One.enabled = false;
        Two.enabled = false;
        Three.enabled = false;
        Four.enabled = false;
        Five.enabled = false;
        Six.enabled = false;
        karmabar.value = playerRef.karma;
    }
    void Update()
    {
        SCORE.text = "Score" + playerRef.score;
        karmabar.value = playerRef.karma;
        if (playerRef.hp <= 0)
        {
            One.enabled = false;
            Two.enabled = false;
            Three.enabled = false;
            Four.enabled = false;
            Five.enabled = false;
            Six.enabled = false;
        }
        if (playerRef.hp >= 6)
        {
            One.enabled = true;
            Two.enabled = true;
            Three.enabled = true;
            Four.enabled = true;
            Five.enabled = true;
            Six.enabled = true;
        }
        else
        {
            if (playerRef.hp >= 5)
            {
                One.enabled = true;
                Two.enabled = true;
                Three.enabled = true;
                Four.enabled = true;
                Five.enabled = true;
                Six.enabled = false;
            }
            else
            {
                if (playerRef.hp >= 4)
                {
                    One.enabled = true;
                    Two.enabled = true;
                    Three.enabled = true;
                    Four.enabled = true;
                    Five.enabled = false;
                    Six.enabled = false;
                }
                else
                {
                    if (playerRef.hp >= 3)
                    {
                        One.enabled = true;
                        Two.enabled = true;
                        Three.enabled = true;
                        Four.enabled = false;
                        Five.enabled = false;
                        Six.enabled = false;
                    }
                    else
                    {
                        if (playerRef.hp >= 2)
                        {
                            One.enabled = true;
                            Two.enabled = true;
                            Three.enabled = false;
                            Four.enabled = false;
                            Five.enabled = false;
                            Six.enabled = false;
                        }
                        else
                        {
                            if (playerRef.hp >= 1)
                            {
                                One.enabled = true;
                                Two.enabled = false;
                                Three.enabled = false;
                                Four.enabled = false;
                                Five.enabled = false;
                                Six.enabled = false;
                            }
                         }
                    }
                }
            }
        }
    }
}




