using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject boss;
    private float timeLeft = 35.0f;
    public GameObject player;

    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0 && boss.gameObject.name == "Demon")
        {
            SceneManager.LoadScene("PassouOne");
        }

        else if (timeLeft < 0 && boss.gameObject.name == "HorseGhost")
        {
            SceneManager.LoadScene("PassouTwo");
        }

        else if (timeLeft < 0 && boss.gameObject.name == "Devil")
        {
            SceneManager.LoadScene("PassouThree");
        }


        else if (timeLeft < 0 && boss.gameObject.name == "Satan")
        {
            SceneManager.LoadScene("Final");
        }

        if (player.transform.position.x < -9.44f && boss.gameObject.name == "Demon")
        {
            player.transform.position = new Vector3(-9.44f, player.transform.position.y, transform.position.z);
        }

        else if(player.transform.position.x < -10.1f && boss.gameObject.name == "HorseGhost")
        {
            player.transform.position = new Vector3(-10.1f, player.transform.position.y, transform.position.z);
        }

        else if (player.transform.position.x < -10.16f && boss.gameObject.name == "Devil")
        {
            player.transform.position = new Vector3(-10.16f, player.transform.position.y, transform.position.z);
        }

        else if (player.transform.position.x < -10.23f && boss.gameObject.name == "Satan")
        {
            player.transform.position = new Vector3(-10.23f, player.transform.position.y, transform.position.z);
        }
    }

}
    
