
//PlayerがRoom1に入ったかどうかの検知スクリプト
//Room1（目的地となる部屋の空のオブジェクト）にアタッチ
//Room1にはBoxColliderをつけておいて、エリアの大きさ等はその部屋の大きさに合うようにその都度調整
//Room1のBoxColliderのis Triggerにチェックを入れる

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectiveAreaScript : MonoBehaviour
{
    public GameObject Arrow;        //矢印を取得

    public void OnTriggerEnter(Collider other)      //Collider型のother（このスクリプトがアタッチされているオブジェクト以外）がエリアに入ったかを判定する関数
    {
        Arrow.SetActive(false);     //矢印を非アクティブにする
    }
}
