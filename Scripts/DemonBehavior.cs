using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class DemonBehavior : MonoBehaviour {

    [SerializeField] private int health;
    public int numOfHearts;

    public Image[] darkHearts;
    public Sprite fullDarkHeart;
    public Sprite emptyDarkHeart;

    private Rigidbody2D rigi;

    // Use this for initialization
    void Start () {
        rigi = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        
        
        if(health == 0)
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene("LevelTwo");
        }
    }
}

