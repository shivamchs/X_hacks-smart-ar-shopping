using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class welcome : MonoBehaviour
{
    public void startshopping()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //welcome message
    }
}
