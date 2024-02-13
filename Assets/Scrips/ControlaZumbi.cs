using UnityEngine;
// ReSharper disable All

public class ControlaZumbi : MonoBehaviour
{
    public GameObject Player;
    public float Velocidade = 8;
    public ControlaJogador ScriptPlayer;

    private void Start()
    {
        ScriptPlayer = GameObject.FindWithTag("Player").GetComponent<ControlaJogador>();
        // Faz com que o zumbi persiga o Game Object com a tag player
        Player = GameObject.FindWithTag("Player");
        // Sorteia um numero de 1 a 25 (Ele não pega o ultimo, no caso 26)
        int RandomSkin = Random.Range(1, 26);
        // Ativa uma das skins do zumbi baseado no numero sorteado a cima
        transform.GetChild(RandomSkin).gameObject.SetActive(true);
    }

    void FixedUpdate()
    {
        Vector3 direcao = Player.transform.position - transform.position;

        //calcular distanca entre jogar e zumbi
        float distancia = Vector3.Distance(transform.position, Player.transform.position);

        //Calcula a dire��o que o player est� baseado no calculo da vari�vel dire��o
        Quaternion Rotacao = Quaternion.LookRotation(direcao);
        // rotaciona o rigidbody baseado no calculo feito na vari�vel Rotacao
        // MoveRotation sempre espera uma vari�vel do tipo Quaternion
        GetComponent<Rigidbody>().MoveRotation(Rotacao);

        // se a distancia for maior que 2.5
        if (distancia > 2.5)
        {
            // faz com que a posi��o do rigidbody se desloque para a posi��o do jogador
            GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + direcao.normalized * Velocidade * Time.fixedDeltaTime);

            // Aplica anima��o de caminhada quando o inimigo estiver longe do player
            GetComponent<Animator>().SetBool("Ataque", false);
        }
        else
        {
            // Aplica anima��o de ataque quando o zumbi parar de se mover
            GetComponent<Animator>().SetBool("Ataque", true);
        }
    }

    // Criado um novo metodo com o mesmo nome do evento marcado na anima��o de atacar o jogador, aqui ser� colocado a fun��o de reiniciar o jogo quando a anima��o chegar naquele evento
    void AtacaJogador()
    {
        ScriptPlayer.TomarDano();
    }
}
