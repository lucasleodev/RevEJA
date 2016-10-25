using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class configsGame : MonoBehaviour {

   public Toggle botaoTelaCheia;



    // Use this for initialization
    void Start() {

     if(Screen.fullScreen == true)
        {
            botaoTelaCheia.isOn = true;
        }
     else
        {
            botaoTelaCheia.isOn = false;
        }
    }
	
	// Update is called once per frame
	void Update () {

    }

    public void Resolucao()
    {

    }

    public void TelaCheia()
    {
        
        if (botaoTelaCheia.isOn == true)
        {
            Screen.fullScreen = true;            
        }
        else
        {
            Screen.fullScreen = false;            
        }
    }

    public void VoltarAoMenu()
    {
        SceneManager.LoadScene("mainMenu");
    }
}
