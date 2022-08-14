using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    PlayerController player;
    void Start()
    {
        player = FindObjectOfType<PlayerController>();

    }
    // Update is called once per frame
    void Update()
    {
      if(player.isDead)
        {
            Invoke("RestartGame", 1);
        }
    }
    public void RestartGame()
    {
        Scene scene =SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

}
