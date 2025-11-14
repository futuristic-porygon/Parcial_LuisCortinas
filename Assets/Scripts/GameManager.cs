using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{

    public GameObject objetoPrefab;
    public TMP_Text contador;
    public GameObject pantallaVictoria;

    private float tiempoEntreSpawnMin = .5f;
    private float tiempoEntreSpawnMax = 3.5f;

    private float sigSpawn;

    private Vector3 rangoSpawner = new Vector3(5f, 3f, 5f);

    private float timer;

    private int puntos = 0;
    private int puntosParaReiniciarJuego = 20;


    private void Start()
    {
        if (pantallaVictoria != null)
            pantallaVictoria.SetActive(false);
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= sigSpawn)
        {
            SpawnTarget();
            timer = 0f;

            sigSpawn = Random.Range(tiempoEntreSpawnMin, tiempoEntreSpawnMax);
        }
    }

    void SpawnTarget()
    {

        GameObject oldTarget = GameObject.FindWithTag("Target");
        if (oldTarget != null)
        {
            Destroy(oldTarget);
        }


        Vector3 spawnPos = new Vector3(
            Random.Range(-rangoSpawner.x, rangoSpawner.x),
            Random.Range(1f, rangoSpawner.y),
            Random.Range(-rangoSpawner.z, rangoSpawner.z)
        );

        Instantiate(objetoPrefab, spawnPos, Quaternion.identity);
    }

    public void Contador()
    {
        puntos++;
        contador.text = puntos + " /20";

        if (puntos >= puntosParaReiniciarJuego)
        {
            PantallaVictoria();
            StartCoroutine(AutoReiniciar());
        }
    }

    void PantallaVictoria()
    {
        Time.timeScale = 0f;
        pantallaVictoria.SetActive(true);
    }

    IEnumerator AutoReiniciar()
    {
        yield return new WaitForSecondsRealtime(2f);
        ReiniciarJuego();
    }

    void ReiniciarJuego()
    {
        Scene juego = SceneManager.GetActiveScene();
        SceneManager.LoadScene(juego.name);
    }
}


