using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AmpulhetaInversa : MonoBehaviour {

    Image ampul;
    float qtdTempo = 10;
    float timer;
    public Text labelTempo;


    // Use this for initialization
    void Start()
    {
        ampul = this.GetComponent<Image>();
        timer = qtdTempo;
        


    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            //ampul.fillAmount += 0.001f;
            ampul.fillAmount += (timer / qtdTempo)/1000 ;
        }
    }
}
