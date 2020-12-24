using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDemon : MonoBehaviour {
    [SerializeField] private float speed;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {   
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if(transform.position.x < -2.6)
        {
            transform.position = new Vector3(7.49f, 0, 0);
        }
    }
}
