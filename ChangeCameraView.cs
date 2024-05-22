//空のゲームオブジェクトにアタッチ
//コンポーネントのMainCameraにMainCameraを、Camera2に切替後のカメラをアタッチ
//予めCamera2を非アクティブにしておく（チェックを外す）
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{
    [SerializeField]
    private GameObject MainCamera;

    [SerializeField]
    private GameObject Camera2;
    
    void Update()
    {
        if(Input.GetKeyDown("1"))       //GetKeyDownは()の中のキーを押したフレームの間だけtureを返す
        {
            MainCamera.SetActive(!MainCamera.activeSelf);   //MainCameraがアクティブかどうかを調べ、逆の状態にする
            Camera2.SetActive(!Camera2.activeSelf);     //Camera2がアクティブかどうかを調べ、逆の状態にする
        }
    }
}
