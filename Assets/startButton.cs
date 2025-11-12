using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startButton : MonoBehaviour
{
    // Start is called before the first frame update
    public void StartButton()
    {
        GameObject.Find("MenuManager").GetComponent<MenuManagerScript>().StartPressed();
        SceneManager.LoadScene("Level-1");
    }
}
