using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;                   //UIを使えるようにするため
using UnityEngine.SceneManagement;      //シーン切り替えできるようにするため

public class DetectionScript : MonoBehaviour
{
    public Text textUI;     //インスペクターウィンドウで表示させたいUIを設定するための変数

    void Start()
    {
       textUI.text = "";        //最初は何も表示させたくないので ""（空欄）
    }

    private void OnTriggerEnter(Collider other)     //PlayerがDetectionAreaに入ったときに
    {
       textUI.text = "Press Enter Key";             //Press Enter Keyと表示させる
    }

    private void OnTriggerStay(Collider other)      //PlayerがDetectionAreaに入っている間
    {
        if(Input.GetKey(KeyCode.Return))            //エンターキーを押したら
        {
            SceneManager.LoadScene("2F");       //2Fをロードする（2Fのところは変えたいシーン名を入れる）
        }
    }

    private void OnTriggerExit(Collider other)      //PlayerがDetectionAreaから出たとき
    {
        textUI.text = "";                           //Press Enter Keyを画面から消す（空欄にする）
    }
}
