using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManger : MonoBehaviour
{
    public GameObject player;
    public GameObject start_portal;
    public Vector2 death_position;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y <= death_position.y)
        {
            player.transform.position = start_portal.transform.position;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("reload");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

}
