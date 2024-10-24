using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TravisMove : MonoBehaviour
{
    private float moveH;
    private float moveV;
    private Rigidbody rb;
    [SerializeField] private float velocidade;
    [SerializeField] private float forcaPulo;
    [SerializeField] private int pontos;
    private bool estaVivo;
    private TextMeshProUGUI textoPontos;
    private TextMeshProUGUI textoTotal;

    [Header("Sons Do Travis")]
    [SerializeField] private AudioClip pulo;
    [SerializeField] private AudioClip pegaCubo;
    private AudioSource audioPlayer;


    // Start is called before the first frame update
    void Start()
    {
        estaVivo = true;
        rb = GetComponent<Rigidbody>();
        audioPlayer = GetComponent<AudioSource>();
        textoPontos = GameObject.FindGameObjectWithTag("Pontos").GetComponent<TextMeshProUGUI>();
        textoTotal = GameObject.Find("Total").GetComponent<TextMeshProUGUI>();
        textoTotal.text = GameObject.FindGameObjectsWithTag("CuboBrilhante").Length.ToString();
    }
    

    // Update is called once per frame
    void Update()
    {
        if (estaVivo)
        {
            moveH = Input.GetAxis("Horizontal");
            moveV = Input.GetAxis("Vertical");

            transform.position += new Vector3(
                moveH * velocidade * Time.deltaTime, 0,
                moveV * velocidade * Time.deltaTime
                );

            //pulo
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(transform.up * forcaPulo, ForceMode.Impulse);
                audioPlayer.PlayOneShot(pulo);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CuboBrilhante"))
        {
            Destroy(other.gameObject);
            audioPlayer.PlayOneShot(pegaCubo);
            pontos++;
            VerificaObjetivos();
            textoPontos.text = pontos.ToString();
        }

          else if (other.gameObject.CompareTag("Lava"))
            {

                SceneManager.LoadScene("GameOver");
            }
        }


    private void VerificaObjetivos()
    {
        int totalCubos = Int32.Parse(textoTotal.text);
        TextMeshProUGUI objetivo = GameObject.Find("Objetivo").GetComponent<TextMeshProUGUI>();
        Debug.LogFormat($"Pontos: {pontos}, Total Cubos: {totalCubos}");

        if (pontos < totalCubos)
        {
            objetivo.text = "Pegue todos os cubos!";
        }

        if (pontos >= totalCubos / 2)
        {
            objetivo.text = "Playboi carti está orgulhoso!";
        }

        if (pontos >= totalCubos - 5)
        {
            objetivo.text = "TA QUASE, FWEH!";
        }

        if (pontos == totalCubos)
        {
            objetivo.text = "Todos os cubos coletados!";
        }
    }
}