using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalDynamicImageRotation : MonoBehaviour{
    [SerializeField] Transform _cameraTransform;
    // ローテーションするときの1枚の画像の幅
    [SerializeField] float _imageWidth;
    // 中心の画像の中心のx座標から左右の画像の中心のx座標までの差(重ねた時用)
    [SerializeField] float _coordinateX;
    float fixed_imageWidth;
    Transform _parentLayer;
    Transform _transformCache;
    [HideInInspector] public bool hasTransformed; //RandomImageへの連絡用

    private void Awake(){
        _parentLayer = this.GetParent().transform;
        _transformCache = transform;
        if (!_cameraTransform){
            this.enabled = false;
        }
        hasTransformed = false;
        fixed_imageWidth = (_imageWidth + _coordinateX * 2) / 3; //重なったところを考慮したときの1枚当たりの長さ
    }

    private void Update(){
        // 3枚でローテーションするのでカメラの描画範囲から1.7枚分ずれたらその方向に移動する
        var distance = _cameraTransform.position - _transformCache.position;
        if(Mathf.Abs(distance.x) > fixed_imageWidth * 1.7f){
            float amount = _coordinateX * 3 * (distance.x < 0 ? -1.0f : 1.0f);
            _transformCache.AddLocalPosX(amount);
            hasTransformed = true;
        }
    }
}

// ユーティリティ
public static class HorizontalDynamicImageRotationExtensions{
    // 親を取得
    public static GameObject GetParent(this Component self){
        return self.transform.parent.gameObject;
    }
    // X方向に値を足す
    public static void AddLocalPosX(this Transform self, float x){
        Vector3 vec3 = self.localPosition;
        vec3.x += x;
        self.localPosition = vec3;
    }
}