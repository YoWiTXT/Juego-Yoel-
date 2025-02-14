using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public void _LoadScene()
    {
       SceneManager.LoadScene("Level01");
    }
}
