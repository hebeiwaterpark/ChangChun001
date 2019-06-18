using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartController : MonoBehaviour
{
    public void EventFunc()
    {

        SceneManager.LoadScene("LoginScene");
    }
}
