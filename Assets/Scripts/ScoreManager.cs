using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    //private ScoreManager _scoreObject;
    private Text _scoreText;
    private int _score=0;
    private string _scoreFormat = "Score: ";

    // Start is called before the first frame update
    void Start()
    {
        //this._scoreObject = this.GetComponent<ScoreManager>();
        this._scoreText = this.GetComponent<Text>();
        this.ResetScore();
    }

    // Update is called once per frame
    void Update()
    {
        _scoreText.text = _scoreFormat+_score.ToString();
    }

    public void AddScore(int score)=> _score+=score;
    public void ResetScore() => _score = 0;
}
