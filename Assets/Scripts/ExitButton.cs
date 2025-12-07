using System.Collections;
using System.Collections.Generic;
using System.Security.Permissions;
using UnityEditor.SearchService;
using UnityEngine;

public class ExitButton : MonoBehaviour
{
    // Start is called before the first frame update
    public void Exit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
