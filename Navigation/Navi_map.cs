
//空のオブジェクトにアタッチ
//マップのインスペクターウィンドウのMapScriptにMap_imageをアタッチ

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapScript : MonoBehaviour
{

    public GameObject Map_image;        //マップを取得

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))     //スペースを押したら
        {
            Cursor.visible = true;          //マウスカーソルを見えるようにする
           Map_image.SetActive(!Map_image.activeSelf);      //マップが非アクティブ可動かを調べ、アクティブにする
        }

        if(!Map_image.activeSelf)           //マップが非アクティブなら
        {
            Cursor.visible = false;         //マウスカーソルが見えなくなるようにする
        }
    }
}
