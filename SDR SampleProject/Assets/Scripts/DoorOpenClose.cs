// Inspectorウィンドウの automaticDoorAnimatorにBaseDoorをアタッチ
// アニメーション等は DoorOpen&Close SampleProjectを参照（自分用なので気にしないで）
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticDoor : MonoBehaviour
{
    // ドアのアニメーター
    [SerializeField]
    [Tooltip("自動ドアのアニメーター")]
    private Animator automaticDoorAnimator;

    // 自動ドア検知エリアに入ったとき
    private void OnTriggerEnter(Collider other)　　             //OnTriggerEnterはオブジェクトが検知エリアに侵入したときの関数
    {                                                          //Collider型のotherと言う名前の変数をとる。プレイヤーがエリアに入ったときに呼び出されるのでother
        // アニメーションパラメータをtrueにする。（ドアが開く）
        automaticDoorAnimator.SetBool("Open", true);
    }
    
    // 自動ドア検知エリアを出たとき
    private void OnTriggerExit(Collider other)                 //OnTriggerEnterはオブジェクトが検知エリアから出たときの関数
    {                                                          //プレイヤーがエリアから出たときに呼び出されるのでother
        //アニメーションパラメータをfalseにする。（ドアが閉まる）
        automaticDoorAnimator.SetBool("Open", false);
    }
}
