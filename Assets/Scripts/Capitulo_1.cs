﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capitulo_1 : BaseCapitulo {

    //Variaveis;

    public int parte, evento;

    public bool RodarParte { get; set; }
    public bool RodarEvento { get; set; }
    public int Evento { get; set; }
    public int Parte { get; set; }
    

    private void Start()
    {
        //RodarParte = false;
    }

    public void comecar()
    {
        RodarParte = true;
        RodarEvento = true;

        Evento = evento;
        Parte = parte;
    }

    private void Update()
    {
        
        if (RodarParte)
        {
            if(RodarEvento && Evento == 0){
                //Evento Vazio;
            }
            else if (RodarEvento && Evento == 1)
            {
                hud_TelaPreta.SetActive(true);
                InicioDatilografia("Fala1");
                Evento++;
            }
            else if (RodarEvento && Evento == 2)
            {
                StartCoroutine("Evento2");
                Evento++;
            }
            else if (RodarEvento && Evento == 3)
            {
                Tutorial();
                Invoke("Tutorial", 3.0f);
                player.AndarPlayer();
                Evento = 0;
            }
            else if (RodarEvento && Evento == 4)
            {
                print("entrou...Evento4");
                
                player.PararPlayer();
                player.ResetarVezesVasculhou("Bedroom", 1);
                Evento = 0;
                StartCoroutine("Evento4");
            }
            else
            {
               
            }
            evento = Evento;
            RodarEvento = false;
        }
        else
        {
            print("Nenhuma parte foi rodada!");
        }
        parte = Parte;
    }
    #region Métodos/Funções
    public void Tutorial()
    {
        if (hud_Tutorial.activeSelf)
        {
            hud_Tutorial.SetActive(false);
        }
        else
        {
            hud_Tutorial.SetActive(true);
        }
    }

    #endregion
    #region CutScene/Configurações

    private IEnumerator Evento2()
    {
        MudarCenario("Bedroom");
        yield return new WaitForSeconds(0.3f);

        telaPreta.SetTrigger("fadeIn");
        SetarPosicao(objeto_Player, -5.78f, -1.72f);
        telaPreta.SetTrigger("fadeIn");
        Datilografia("Fala2");
        player.PararPlayer();
    }
    private IEnumerator Evento4(){

        telaPreta.SetTrigger("fadeOut");

        yield return new WaitForSeconds(1f);
        MudarCenario("Redroom");
        SetarPosicao(objeto_Player, -5.15f, -1.5f);
        yield return new WaitForSeconds(0.2f);
        telaPreta.SetTrigger("fadeIn");
        player.AndarPlayer();
    }

    #endregion
}
