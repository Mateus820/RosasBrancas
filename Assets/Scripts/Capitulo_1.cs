﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capitulo_1 : BaseCapitulo {

    //Variaveis;
    public int parte, evento, mostrarParte;

    public bool RodarParte { get; set; }
    public bool RodarEvento { get; set; }
    public int Evento { get; set; }
    public int Parte { get; set; }
    public int EscolhaAtual{ get; set; }
    
    private void Start()
    {
        //PlayerPrefs;
        PlayerPrefs.SetInt("escolha", 0);
    }

    public void comecar()
    {
        Evento = evento;
        Parte = parte;

        RodarParte = true;
        RodarEvento = true;
    }

    private void Update()
    {

        //Verifica se vasculhou todos os objetos da cena;
        VerificarTodosObjetos();
        mostrarParte = parte;

        EscolhaAtual =  PlayerPrefs.GetInt("escolha");

        if (RodarParte && Parte == 1)
        {
            if(RodarEvento && Evento == 0){
                //Evento Vazio;
            }
            else if (RodarEvento && Evento == 1){
                player.TrocarEstado("Crianca");
                hud_TelaPreta.SetActive(true);
                InicioDatilografia("Fala1", 1);
                Evento++;
            }
            else if (RodarEvento && Evento == 2){
                StartCoroutine("Evento2");
                Evento++;
            }
            else if (RodarEvento && Evento == 3){   
                Tutorial();
                Invoke("Tutorial", 3.0f);
                player.AndarPlayer();
                Evento = 0;
            }
            else if (RodarEvento && Evento == 4)
            {   
                player.PararPlayer();
                player.ResetarVezesVasculhou("Bedroom", 1);
                Evento = 0;
                StartCoroutine("Evento4");
            }
            else if(RodarEvento && Evento == 5){
                Datilografia("Fala4", 1);
                player.cenaObjetos = 1;
                Evento = 0;
            }
            else if(RodarEvento && Evento == 6){
                StartCoroutine("Evento6");
                Evento++;
            }
            else if(RodarEvento && Evento == 7){
                hud_Escolhas.SetActive(true);
                script_Escolha.SetarEscolhas("Sair", 50, "Não Sair", 45, 300, 100, 300, 100);
                Evento++;
            }
            else if(RodarEvento && Evento == 8 && EscolhaAtual == 1){
                StartCoroutine("Evento8_Esc1");
                Parte++;
                Evento = 1;
            }
            else if(RodarEvento && Evento == 8 && EscolhaAtual == 2){
                Datilografia("Fala6_Esc2", 1);
                Evento++;
            }
            else if(RodarEvento && Evento == 9 && EscolhaAtual == 2){
                personagem.Mover("Pai", 4.5f, true, 2.3f);
                Parte++;
                Evento = 1;
            }
            else{
                print("Nenhum Evento Rodou!");
            }
            evento = Evento;
            RodarEvento = false;
        }
        else if(RodarParte && Parte == 2){

            if(RodarEvento && Evento == 0){
                //Evento Vazio;
            }
            else if(RodarEvento && Evento == 1){
                
                hud_TelaPreta.SetActive(true);
                hud_TelaPreta.SetActive(true);

                player.cenaObjetos = 1;
                player.ResetarVezesVasculhou("Bedroom", 1);
                player.ResetarVezesVasculhou("Redroom", 2);

                StartCoroutine(Evento1_Pt2());
                Evento++;
            }
            else if(RodarEvento && Evento == 2){

                hud_IntroducaoCapitulo.SetActive(true);

                StartCoroutine(Evento2_Pt2());
                Evento++;
            }
            else if(RodarEvento && Evento == 3){
                StartCoroutine(Evento3_Pt2());
                Evento++;
            }
            else if(RodarEvento && Evento == 4){
                StartCoroutine(Evento4_Pt2());
                player.AndarPlayer();
                Evento = 0;
            }
            else if(RodarEvento && Evento == 5){
                personagem.Mover("Raquel", 4f, true, 2.5f);
                Evento = 0;
            }
            else if(RodarEvento && Evento == 6){
                personagem.Mover("Harvey", 4f, false, 3.5f);
                Evento = 7;
            }
            else if(RodarEvento && Evento == 7){
                Datilografia("Fala10", 1);
                Evento = 8;
            }
            else if(RodarEvento && Evento == 8){
                hud_Escolhas.SetActive(true);
                script_Escolha.SetarEscolhas("As pessoas comentam...", 32, "Você sabe que eu\n namoro com ela", 30, 500, 100, 500, 100);
                Evento = 0;
            }
            else if(RodarEvento && Evento == 9 && EscolhaAtual == 1){

            }
            else{

            }
        }
        else
        {
            print("Nenhuma Parte Rodou");
        }

        RodarParte = false;
    }
    #region Métodos/Funções
    private void VerificarTodosObjetos(){
        player.VasculharTodosObjetos("Redroom", 1);
    }
    private void Tutorial()
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
    #region CutScene/Configurações Parte_1

    private IEnumerator Evento2(){
        MudarCenario("Bedroom");
        yield return new WaitForSeconds(0.3f);

        telaPreta.SetTrigger("fadeIn");
        SetarPosicao(objeto_Player, -5.78f, -1.72f);
        telaPreta.SetTrigger("fadeIn");
        Datilografia("Fala2", 1);
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
        Datilografia("Fala3", 1);
    }
    private IEnumerator Evento6(){
        
        player.PararPlayer();

        telaPreta.SetTrigger("fadeOut");
        yield return new WaitForSeconds(1f);
        MudarCenario("Redroom");

        personagem.Chamar("Pai", -5f, -1.5f);
        objeto_Player.SetActive(false);

        yield return new WaitForSeconds(0.3f);
        telaPreta.SetTrigger("fadeIn");

        yield return new WaitForSeconds(0.5f);
        Datilografia("Fala5", 1);
    }
    private IEnumerator Evento8_Esc1(){

        telaPreta.SetTrigger("fadeOut");
        yield return new WaitForSeconds(2f);

        objeto_Player.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        telaPreta.SetTrigger("fadeIn");

        yield return new WaitForSeconds(0.7f);
        Datilografia("Fala6_Esc1", 1);
    }
    #endregion
    #region CutScene/Configurações Parte_2


    private IEnumerator Evento1_Pt2(){

        
        telaPreta.SetTrigger("fadeOut");
        yield return new WaitForSeconds(2f);

        objeto_Player.SetActive(true);
        SetarPosicao(objeto_Player, -6f, -1.5f);
        player.PararPlayer();
        player.TrocarEstado("Jovem");
        MudarCenario("Bedroom");
        personagem.RemoverCena("Pai");

        yield return new WaitForSeconds(1f);
        InicioDatilografia("Fala7", 1);
    }
    private IEnumerator Evento2_Pt2(){
         
        yield return new WaitForSeconds(0.3f);
        introText.text = "Alguns anos depois...";
        introCapitulo.SetTrigger("fadeIn");

        yield return new WaitForSeconds (3f);
        introCapitulo.SetTrigger("fadeOut");

        yield return new WaitForSeconds(1f);
        telaPreta.SetTrigger("fadeIn");

        RodarEvento = true;
        RodarParte = true;
    }
    private IEnumerator Evento3_Pt2(){

        telaPreta.SetTrigger("fadeIn");
        yield return new WaitForSeconds(1f);
        Datilografia("Fala8", 1);
    }
    private IEnumerator Evento4_Pt2(){
        telaPreta.SetTrigger("fadeOut");
        yield return new WaitForSeconds(1f);
        MudarCenario("School");
        player.cenaObjetos = 1;
        SetarPosicao(objeto_Player, 6f, -1.5f);
        personagem.Chamar("NPC1", -3f, -1.5f);
        personagem.Chamar("NPC2", -1f, -1.5f);
        yield return new WaitForSeconds(0.2f);
        telaPreta.SetTrigger("fadeIn");
        yield return new WaitForSeconds(1f);
        Datilografia("Fala9", 1);
        player.AndarPlayer();
    }

    #endregion
}
