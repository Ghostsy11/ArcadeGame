using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class keepScore : MonoBehaviour
{

    private TextMeshProUGUI scoreField;
    private int score = 0; 
    // Start is called before the first frame update
    void Start()
    {
        scoreField= GetComponent<TextMeshProUGUI>();
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(scoreField.text);
        scoreField.text = "HuntingScore:" + score;
    }

    public void AddScore(int add)
    {
       // Debug.Log(add);
        score += add;
        scoreField.text = "HuntingScore:" + score;
       // Debug.Log(score);
       // Debug.Log(scoreField.text);
        
    }
}
    