using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public GameObject canvas;
    public GameObject shooter;
    public int score;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        canvas.GetComponent<TextMesh>().text = "Score: 0";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        float shooter_x = shooter.transform.position.x;
        float shooter_y = shooter.transform.position.y;

        float dist_sq = 64.0f;

        if (((shooter_x-gameObject.transform.position.x)* (shooter_x - gameObject.transform.position.x) + (shooter_y - gameObject.transform.position.y) * (shooter_y - gameObject.transform.position.y)) > dist_sq) {
            score += 3;
        }
        else
        {
            score += 2;
        }
        canvas.GetComponent<TextMesh>().text = "Score: " + score;
    }
}
