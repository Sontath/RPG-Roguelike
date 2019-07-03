using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject Menu;
    public bool playAgain = false;

    // Update is called once per frame
    void Update()
    {

        if (playAgain == false && transform.childCount == 0)
        {
            playAgain = true;
            PlayAgain();
        }
    }

    private void PlayAgain()
    {
        Debug.Log("Game Over");
        Menu.SetActive(true);
    }
}
