using UnityEngine;

public class TanqueSimulacion : MonoBehaviour
{
    // 🔹 Parámetros iniciales
    public float capacidadMaxima = 500f;
    public float flujoEntrada = 30f;
    public float flujoSalida = 20f;

    // 🔹 Variable de estado
    public float volumenActual;

    // 🔹 Tiempo
    public float tiempo = 0f;
    public float deltaTiempo = 1f;

    // 🔹 Referencia visual
    public Transform agua;

    void Start()
    {
        volumenActual = 0f;
    }

    void Update()
    {
        Simulate();
        DrawView();
    }

    void Simulate()
    {
        if (volumenActual < capacidadMaxima)
        {
            float flujoNeto = flujoEntrada - flujoSalida;
            volumenActual += flujoNeto * deltaTiempo;

            if (volumenActual > capacidadMaxima)
            {
                volumenActual = capacidadMaxima;
            }
        }

        tiempo += deltaTiempo;
    }

    void DrawView()
    {
        // Escala del agua
        float altura = volumenActual / capacidadMaxima;

        agua.localScale = new Vector3(2.5f, altura * 5f, 2.5f);

        // Ajustar posición para que crezca hacia arriba
        agua.localPosition = new Vector3(0, (-2.5f + (altura * 2.5f)), 0);

        Debug.Log("Tiempo: " + tiempo + " | Volumen: " + volumenActual);
    }
}