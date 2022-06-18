using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    // �{�[����������Z�ŏ��l
    private float _visiblePosZ = -6.5f;

    // �Q�[���I�[�o�[�e�L�X�g
    private GameObject _gameoverText;
    // Find �{���Ώۖ�
    private string _obj = "GameOverText";
    // TMP�̂ق�
    //private string _obj2 = "_GameOverText";

    // �X�R�A�e�L�X�g
    private GameObject _scoreTextObj;
    // �X�R�A�Ǘ��}�l�[�W���[
    private ScoreManager _scoreManager;

    // �L�[�{�[�h�ݒ�ύX
    KeyCode _leftfrip = KeyCode.A;
    KeyCode _rightfrip = KeyCode.D;
    KeyCode _bothfrip = KeyCode.S;

    // Start is called before the first frame update
    void Start()
    {
        this._gameoverText = GameObject.Find(_obj);
        //this._gameoverText = GameObject.Find(_obj2);

        // �X�R�A�Ǘ��}�l�[�W���[�̎擾
        _scoreTextObj = GameObject.FindWithTag(TagName.ScoreTextTag);
        _scoreManager= _scoreTextObj.GetComponent<ScoreManager>();

        // �L�[�{�[�h�ݒ�ύX
        KeyboardController.BindForKeyboard(_leftfrip, _rightfrip,_bothfrip);
    }

    // Update is called once per frame
    void Update()
    {
        // �{�[������ʊO�ɏo���ꍇ
        if (this.transform.position.z < this._visiblePosZ)
        {
            this._gameoverText.GetComponent<Text>().text = "Game Over";
            // TMP�p�^�ύX
            //this._gameoverText.GetComponent<TextMeshProUGUI>().text = "Game Over";
        }

    }

    private void OnCollisionEnter(Collision other)
    {
        // �X�R�A���Z����
        var score = other.gameObject.tag switch
        {
            TagName.SmallStarTag => 10,
            TagName.LargeStarTag => 20,
            _ => 0
        };
        _scoreManager.AddScore(score);

    }
}
