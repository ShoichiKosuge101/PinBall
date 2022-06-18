using UnityEngine;

/// <summary>
/// フリッパー操作クラス
/// </summary>
public class FripperController : MonoBehaviour
{
    protected HingeJoint myHingeJoint;

    // 初期の傾き
    protected float defaultAngle = 20;

    //弾いた時の傾き
    protected float flickAngle = -20;

    // Start is called before the first frame update
    void Start()
    {
        this.myHingeJoint = this.GetComponent<HingeJoint>();

        SetAngle(this.defaultAngle);
        
        // アクセスレベルのチェック
        // KeyboardController.LEFTFRIP = KeyCode.L;
    }

    // フリッパーの傾きを設定
    private void SetAngle(float angle)
    {
        // スプリング構造体を取得して
        JointSpring jointSpring = this.myHingeJoint.spring;
        // スプリングの変更先角度を渡して
        jointSpring.targetPosition = angle;
        // スプリングの角度を反映する
        this.myHingeJoint.spring = jointSpring;

        /* cf)構造体フィールドの直接変更はできない
        * _myHingeJoint.spring.targetPosition = this._flickAngle;
        * https://smdn.jp/programming/dotnet-samplecodes/collections/3a702b83024111eb907175842ffbe222/
        */
    }

    // Update is called once per frame
    void Update()
    {
        // 左矢印キーで左フリッパーを動かす
        // 押されている間はフリッパーが上がり続ける(フラグ判定は初回のみ)
        if (Input.GetKeyDown(KeyboardController.LEFTFRIP) && this.gameObject.CompareTag(TagName.LeftFripperTag))
        {
            SetAngle(this.flickAngle);
            //Debug.Log("Left Frip Up");
        }
        // 左矢印キーを離すと位置を戻す
        if (Input.GetKeyUp(KeyboardController.LEFTFRIP) && this.gameObject.CompareTag(TagName.LeftFripperTag))
        {
            SetAngle(this.defaultAngle);
        }

        //右矢印キーで右フリッパーを動かす
        // 押されている間はフリッパーが上がり続ける(フラグ判定は初回のみ)
        if (Input.GetKeyDown(KeyboardController.RIGHTFRIP) && this.gameObject.CompareTag(TagName.RightFripperTag))
        {
            SetAngle(this.flickAngle);
            //Debug.Log("Right Frip Up");
        }
        //右矢印キーを離すと位置を戻す
        if (Input.GetKeyUp(KeyboardController.RIGHTFRIP) && this.gameObject.CompareTag(TagName.RightFripperTag))
        {
            SetAngle(this.defaultAngle);
        }

        // 両フリッパーを動かす
        // 下矢印キーはバインド設定を満たさなくても操作可能
        // 押されている間はフリッパーが上がり続ける(フラグ判定は初回のみ)
        if ((Input.GetKeyDown(KeyboardController.BOTHFLIP) || Input.GetKeyDown(KeyCode.DownArrow)) && 
            ( this.gameObject.CompareTag(TagName.RightFripperTag) || this.gameObject.CompareTag(TagName.LeftFripperTag)))
        {
            SetAngle(this.flickAngle);
            //Debug.Log("Right Frip Up");
        }
        //バインドキーまたは下矢印キーを離すと位置を戻す
        if ((Input.GetKeyUp(KeyboardController.BOTHFLIP) || Input.GetKeyUp(KeyCode.DownArrow)) &&
             (this.gameObject.CompareTag(TagName.RightFripperTag) || this.gameObject.CompareTag(TagName.LeftFripperTag)))
        {
            SetAngle(this.defaultAngle);
        }

    }
}
