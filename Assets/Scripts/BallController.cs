using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    // ボールが見えるZ最小値
    private float _visiblePosZ = -6.5f;

    // ゲームオーバーテキスト
    private GameObject _gameoverText;
    // Find 捜索対象名
    private string _obj = "GameOverText";
    // TMPのほう
    //private string _obj2 = "_GameOverText";

    // スコアテキスト
    private GameObject _scoreTextObj;
    // スコア管理マネージャー
    private ScoreManager _scoreManager;

    // キーボード設定変更
    KeyCode _leftfrip = KeyCode.A;
    KeyCode _rightfrip = KeyCode.D;
    KeyCode _bothfrip = KeyCode.S;

    // Start is called before the first frame update
    void Start()
    {
        this._gameoverText = GameObject.Find(_obj);
        //this._gameoverText = GameObject.Find(_obj2);

        // スコア管理マネージャーの取得
        _scoreTextObj = GameObject.FindWithTag(TagName.ScoreTextTag);
        _scoreManager= _scoreTextObj.GetComponent<ScoreManager>();

        // キーボード設定変更
        KeyboardController.BindForKeyboard(_leftfrip, _rightfrip,_bothfrip);
    }

    // Update is called once per frame
    void Update()
    {
        // ボールが画面外に出た場合
        if (this.transform.position.z < this._visiblePosZ)
        {
            this._gameoverText.GetComponent<Text>().text = "Game Over";
            // TMP用型変更
            //this._gameoverText.GetComponent<TextMeshProUGUI>().text = "Game Over";
        }

    }

    private void OnCollisionEnter(Collision other)
    {
        // スコア加算条件
        var score = other.gameObject.tag switch
        {
            TagName.SmallStarTag => 10,
            TagName.LargeStarTag => 20,
            _ => 0
        };
        _scoreManager.AddScore(score);

    }
}
