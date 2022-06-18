using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudController : MonoBehaviour
{
    //ç≈è¨ÉTÉCÉY
    private float _minimum = 1.0f;

    //ägëÂèkè¨ÉXÉsÅ[Éh
    private float _magSpeed = 10.0f;

    //ägëÂó¶
    private float _magnification = 0.07f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // â_ÇägëÂèkè¨
        // scale = ((min + Xsin(dt * t)) , y, (min + Xsin(dt * t)))
        this.transform.localScale = new Vector3(this._minimum + Mathf.Sin(Time.time * this._magSpeed) * this._magnification, this.transform.localScale.y, this._minimum + Mathf.Sin(Time.time * this._magSpeed) * this._magnification);
    }
}
