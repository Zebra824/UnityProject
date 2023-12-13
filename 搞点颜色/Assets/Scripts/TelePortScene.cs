using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TelePortScene : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other) {
        // 玩家标签需要更改；挂载到有范围的collider2d上
        if(other.gameObject.CompareTag("Player")){
            Debug.Log("trigger transport");
            // 场景转换，报错情况请再Build Settings中添加需要转换的场景，保存后再尝试转换。
            // LoadScene后的场景转换名称必须精确。
            SceneManager.LoadScene("SampleScene");
        }
    }
}
