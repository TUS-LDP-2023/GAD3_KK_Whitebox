using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    public string sceneName;
    public GameObject key;
    public bool keyCollected;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && keyCollected == true)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
    public void Update()
    {
        if(key == null)
        {
            keyCollected = true;
        }
    }
}
