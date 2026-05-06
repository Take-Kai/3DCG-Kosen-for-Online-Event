using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public GameObject Room1_button;         //部屋１のボタンを取得
    public GameObject Room2_button;         //部屋２のボタンを取得
    public GameObject Room1;                //部屋１に入ったかを判定するオブジェクトを取得
    public GameObject Room2;                //部屋２に入ったかを判定するオブジェクトを取得
    [SerializeField] Transform target1;     //目的地１を取得
    [SerializeField] Transform target2;     //目的地２を取得
    [SerializeField] Transform cursor;      //矢印を取得

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))                //スペースキーが押されたら
        {
            Room1_button.SetActive(!Room1_button.activeSelf);       //部屋１のボタンが非アクティブのときアクティブにする
            Room2_button.SetActive(!Room2_button.activeSelf);       //部屋２のボタンが非アクティブのときアクティブにする
        }

        if(Room1.activeSelf)                     //部屋１に入ったかを判定するオブジェクトがアクティブである間
        {
            cursor.LookAt(target1);             //部屋１を矢印が指し続ける
        }

        if(Room2.activeSelf)                    //部屋２に入ったかを判定するオブジェクトがアクティブである間
        {
            cursor.LookAt(target2);             //部屋２を矢印が指し続ける
        }
    }
}
