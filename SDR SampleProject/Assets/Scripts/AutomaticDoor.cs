using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticDoor : MonoBehaviour
{
    [SerializeField]
    [Tooltip("自動ドアのアニメーター")]
    private Animator automaticDoorAnimator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        automaticDoorAnimator.SetBool("Open", true);
    }

    private void OnTriggerExit(Collider other)
    {
        automaticDoorAnimator.SetBool("Open", false);
    }
}
