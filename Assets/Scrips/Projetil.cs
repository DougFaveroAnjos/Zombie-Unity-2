using UnityEngine;
// ReSharper disable All
public class Projetil : MonoBehaviour
{
    public float Velocidade = 20;
    public AudioClip somMorteZumbi;

    // Rodado a cada 0.02 Segundos
    void FixedUpdate()
    {
        // Faz com que o projetil v� em linha reta, � usado o Transform.forward porque o Vector3 reconhece o Eixo Z da Unity e n�o do objeto
        GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position - transform.forward *  Velocidade * Time.fixedDeltaTime);
    }

    // Quando  Trigger entra em contato com algum objeto ele executa os c�digos dentro desse void
    void OnTriggerEnter(Collider ObjColisao)
    {
        // Se a tag do objeto de colis�o for igual a "Inimigo":
        if(ObjColisao.tag == "Inimigo")
        {
            // Destroi o objeto colidido
            Destroy(ObjColisao.gameObject);
            ControlaAudio.instancia.PlayOneShot(somMorteZumbi);
        }
        // Se alto destroi
        Destroy(gameObject);
    }
}
