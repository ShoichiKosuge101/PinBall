using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlightnessRegulator : MonoBehaviour
{
    protected Material myMaterial;

    [Tooltip("emission 最小値")]
    [Range(0,5)]
    [SerializeField] float minEmission = 0.2f;

    [Tooltip("emission 最大値")]
    [Range(0,5)] 
    [SerializeField] float magEmission = 2.0f;

    [Tooltip("発光速度")]
    [Range(0,10)]
    [SerializeField] int speed = 5;
    // 角度
    protected int degree = 0;

    // ターゲットのデフォルト色
    Color defaultColor =Color.white;
    private string _colorName = "_EmissionColor";

    // Start is called before the first frame update
    void Start()
    {
        // タグごとに発光色を分類
        defaultColor = tag switch
        {
            TagName.SmallStarTag => Color.white,
            TagName.LargeStarTag => Color.yellow,
            TagName.SmallCloudTag => Color.cyan,
            TagName.LargeCloudTag => Color.cyan,
            _ => throw new InvalidOperationException($"tag: {tag} is not exist.")
        };

        // material情報の取得
        this.myMaterial = this.GetComponent<Renderer>().material;

        // オブジェクトの最初の色を設定
        // SetColor(colorName,colorValue)
        myMaterial.SetColor(_colorName, this.defaultColor * minEmission);
    }

    // Update is called once per frame
    void Update()
    {
        ///<summary> 
        /// 衝突時の角度情報を起点として発光を変更
        /// 時間経過により発光が正弦変化(180° -> 0°)
        /// デフォルト * 最小発光値に戻る
        /// </summary>
        if (this.degree >= 0)
        {
            // デフォルト色 * (最小emission + sin((rad)角度)*最大emission)
            var emissionColor= this.defaultColor * (this.minEmission + Mathf.Sin(this.degree * Mathf.Deg2Rad) * this.magEmission);
            myMaterial.SetColor(_colorName, emissionColor);

            // 角度を徐々に小さくする
            this.degree -= this.speed;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // 角度を180度に設定
        this.degree = 180;
    }
}
