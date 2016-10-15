using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class configsGame : MonoBehaviour {

    public GameObject botaoVoltarMenu;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void VoltarAoMenu()
    {
        SceneManager.LoadScene("mainMenu");
    }
}
