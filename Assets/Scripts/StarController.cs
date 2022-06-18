using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Starの回転制御クラス
/// 回転量はランダムで決定
/// </summary>
public class StarController : MonoBehaviour
{
    // 回転速度
    // 回転量変更できるようにアクセス変更
    [SerializeField] float rotSpeed = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        // 回転量の設定
        this.transform.Rotate(0, Random.Range(0,360), 0);
    }

    // Update is called once per frame
    void Update()
    {
        // 回転
        this.transform.Rotate(0,this.rotSpeed,0);
    }
}
