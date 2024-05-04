using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
   [SerializeField] private string NomeDaCena;
   [SerializeField] private GameObject painelMenuInicial;
   [SerializeField] private GameObject painelOpcoes;
  public void jogar()
    {
        SceneManager.LoadScene(NomeDaCena);
    }

    public void abriropcao()
    {
        painelMenuInicial.SetActive(false);
        painelOpcoes.SetActive(true);
    }

    public void fecharopcao()
    {
        painelOpcoes.SetActive(false);
        painelMenuInicial.SetActive(true);
        
    }

    public void sair()
    {
        Application.Quit();
    }
}
