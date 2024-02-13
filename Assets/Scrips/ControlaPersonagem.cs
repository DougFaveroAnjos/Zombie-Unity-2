using UnityEngine;
using UnityEngine.SceneManagement;
// ReSharper disable All

public class ControlaJogador : MonoBehaviour
{

    public float Velocidade = 10;
    public LayerMask mascaraChao;
    Vector3 direcao;
    public GameObject textoGameOver;
    public int vida = 100;
    public ControlaBarraVida ControlaVida;
    public AudioClip somDeDano;

    void Start()
    {
        // Ao iniciar a cena novamente o tempo volta a ser definido como 1
        Time.timeScale = 1;
        // Sistema para sortear a skin do personagem ao iniciar o jogo
        int sorteiaSkin = Random.Range(1, 23);
        transform.GetChild(sorteiaSkin).gameObject.SetActive(true);
    }

    void Update()
    {
        //Inputs do Jogador - Guardando teclas apertadas
        float eixoX = Input.GetAxis("Horizontal");
        float eixoZ = Input.GetAxis("Vertical");

        direcao = new Vector3(eixoX, 0, eixoZ);

        //Animações do Jogador
        if (direcao != Vector3.zero)
        {
            // se a direção for diferente de 0 a animação de movimento == true
            GetComponent<Animator>().SetBool("Movendo", true);
        }
        else
        {
            // se a direção for igual a 0 a animação de movimento == false
            GetComponent<Animator>().SetBool("Movendo", false);
        }
    
        // Se o jogador não estiver vivo
        if(vida <= 0)
        {
            // Quando o jogador clicar com o botão esquerdo do Mouse
            if (Input.GetButtonDown("Fire1"))
            {
                // Define a variável Vivo como true novamente
                vida = 100;
                // Recarrega a cena do jogo (Necessário realizar o import do UnityEngine.SceneManagement)
                SceneManager.LoadScene("game");
            }
        }
    }
    
    void FixedUpdate()
    {
        //Movimentação do Jogador por segundo
        GetComponent<Rigidbody>().MovePosition
             // Posilção atual do rigibody menos a posição que quer ir
            (GetComponent<Rigidbody>().position + (direcao * Velocidade * Time.fixedDeltaTime));

        // cria um raio e guarda os valores em uma variável
        Ray raio = Camera.main.ScreenPointToRay(Input.mousePosition);
        // desenha uma linha da origem do raio da variável a cima até a direção final do raio (mouse)
        Debug.DrawRay(raio.origin, raio.direction *100, Color.red);

        RaycastHit impacto;

        // ao usar o a variavel impacto no raycast da unity é necessário usar o termo "out" pois se trata de uma variável vazia
        if(Physics.Raycast(raio, out impacto, 100, mascaraChao))
        {
            //Guardar posição de impacto do raio:
            // Faz um vector 3 com o ponto de impacto do raio a partir da posição do jogador
            Vector3 miraJogador = impacto.point - transform.position;

            //Quaternion para realizar a rotação do personagem
            Quaternion rotacaoPersonagem = Quaternion.LookRotation(miraJogador);
            //Isolando o Z e o X dos eixos do quaternion para utilizar apenas a rotação do Y
            rotacaoPersonagem.z = 0;
            rotacaoPersonagem.x = 0;
            //Rotação do personagem com o quaternion.normalizes (retorna o quaternion com a margnitude = 1)
            GetComponent<Rigidbody>().MoveRotation(rotacaoPersonagem.normalized);
        }
    }

    public void TomarDano()
    {
        vida -= 10;
        ControlaAudio.instancia.PlayOneShot(somDeDano);
        ControlaVida.AtualizaBarraVida();
        if (vida <= 0)
        {
            // Pausa o jogo quando a anima��o chega no evento marcado
            Time.timeScale = 0;
            // Define o textoGameOver do componente como ativo 
            textoGameOver.SetActive(true);
        }
    }
}