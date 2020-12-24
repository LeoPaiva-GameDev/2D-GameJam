using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseSpawn : MonoBehaviour {

    public float timer;
    [SerializeField] private float speed;

    public float minTime;
    public float maxTime;

    public GameObject horse;
    public GameObject ghost;
    public GameObject fireBall;
    public GameObject all;
    public GameObject boss;
    




    public void Start()
    {
        StartCoroutine(Run());
    }

    private IEnumerator Run()
    {
        for (int i = 0; i < 6; i++)
        {
            var time = Random.Range(3f, 10f);
            yield return new WaitForSeconds(time);
            if (boss.gameObject.name == "HorseGhost")
            {
                Instantiate(horse, new Vector3(25.6f, 8.9f, 0), Quaternion.identity);
                //horse.transform.Translate(Vector2.left * speed * Time.deltaTime);
            }

            else if(boss.gameObject.name == "Demon")
            {
                Instantiate(ghost, new Vector3(14.34f, -1.98f, 0), Quaternion.identity);

                //ghost.transform.Translate(Vector2.left * speed * Time.deltaTime);
            }

            else if (boss.gameObject.name == "Devil")
            {
                Instantiate(fireBall, new Vector3(23.26f, -1.21f, 0), Quaternion.identity);

                //ghost.transform.Translate(Vector2.left * speed * Time.deltaTime);
            }

            else if (boss.gameObject.name == "Satan")
            {
                Instantiate(all, new Vector3(20.54f, 0.0f, 0), Quaternion.identity);

                //ghost.transform.Translate(Vector2.left * speed * Time.deltaTime);
            }
        }
    }

}
