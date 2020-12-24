using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {
    public int enemyHealth = 2;

    [SerializeField] private float speed;
    private float dist;

    private Transform target;

    public Player player;

    // Use this for initialization
    void Start () {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        player = GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
        dist = Vector3.Distance(target.position, transform.position);
        if(dist < 21)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }


        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Attacking")
        {
            Destroy(this.gameObject);
        }
    }
}
