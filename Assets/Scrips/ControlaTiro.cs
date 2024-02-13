using UnityEngine;
// ReSharper disable All

public class ControlaTiro : MonoBehaviour
{
    public GameObject Municao;
    public GameObject Disparo;
    public AudioClip somDeTiro;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            //Instantiate serve para criar novo projetil da arma
            Instantiate(Municao, Disparo.transform.position, Disparo.transform.rotation);
            //Aplica som de tiro quando o botão do mouse for pressionado
            ControlaAudio.instancia.PlayOneShot(somDeTiro);
        }
    }
}
