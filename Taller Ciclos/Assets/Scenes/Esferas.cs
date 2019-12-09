using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Clase utilizada para crear esferas con un rango de alto y ancho aleatorio entre 3 y 12.
/// A cada esfera le asigna un color aleatorio entre(white, red, green, gray, blue, yellow, cyan)
/// </summary>
public class Esferas : MonoBehaviour {
    public bool casillaCheckBox;
    int min = 3;
    int max = 13;
    private GameObject[,] grid;

    void Start()
    {
        StartCoroutine(CrearEsferas());
    }

    public IEnumerator CrearEsferas()
    {

        if (casillaCheckBox == true)
        {

            int width = Random.Range(min, max);
            int height = Random.Range(min, max);
            Color colorEsferaPrevia = Color.clear;
            Color colorEsferaActual = Color.clear;

            Debug.Log("El ancho es: " + width + " y el alto es: " + height + " total esferas: " + width * height);

            grid = new GameObject[width, height];
            for (int x = 0; x < width; x++)
            {

                for (int y = 0; y < height; y++)
                {

                    GameObject esfera = GameObject.CreatePrimitive(PrimitiveType.Sphere) as GameObject;
                    Vector3 position = new Vector3(x, y, 0);
                    esfera.transform.position = position;
                    grid[x, y] = esfera;

                    esfera.GetComponent<Renderer>().material.color = ColorAleatorio();

                    yield return new WaitForSeconds(0.3f);

                    GameObject esferaActual = grid[x, y];
                    int xEsferaAnterior = x - 1;
                    int yEsferaActual = y;

                    if (xEsferaAnterior > -1 && xEsferaAnterior < width - 1)
                    {

                        GameObject esferaAnterior = grid[xEsferaAnterior, yEsferaActual];

                        colorEsferaPrevia = esferaAnterior.GetComponent<Renderer>().material.color;
                        colorEsferaActual = esferaActual.GetComponent<Renderer>().material.color;

                        ComparadorDeColores comparadorDeColores = new ComparadorDeColores();

                        esferaAnterior.GetComponent<Renderer>().material.color = comparadorDeColores.ColorAnterior(colorEsferaPrevia, colorEsferaActual);
                        esferaActual.GetComponent<Renderer>().material.color = comparadorDeColores.ColorActual(colorEsferaPrevia, colorEsferaActual);

                    }
                }
            }
        }

        else
        {

            Debug.Log("No se ha seleccionado la check box");

        }
    }

    public Color ColorAleatorio()
    {

        Color colorRandom = Color.black;
        int colorAleatorio = Random.Range(0, 6);

        switch (colorAleatorio)
        {

            case 0:
                colorRandom = Color.white;
                break;
            case 1:
                colorRandom = Color.red;
                break;
            case 2:
                colorRandom = Color.green;
                break;
            case 3:
                colorRandom = Color.gray;
                break;
            case 4:
                colorRandom = Color.blue;
                break;
            case 5:
                colorRandom = Color.yellow;
                break;
            case 6:
                colorRandom = Color.cyan;
                break;

        }

        return colorRandom;
    }

}
/// <summary>
/// Clase utilizada para comparar los colores en una fila de dos esferas, y asignarle el color negro en los casos donde ambas esferas tengan el mismo color.
/// </summary>
/// <return>
/// Devuelve el color negro, en caso de ser verdadera la comparación (colores iguales), o en caso contrario devuelve el color actual de la esfera.
/// </return>
/// <param>
/// Son los colores a evaluar en la comparación.
/// </param>
public class ComparadorDeColores
{

    public Color ColorActual(Color anterior, Color actual)
    {

        Color colorVerificado = actual;
        Color colorDuplicado = Color.black;

            if (anterior == actual)
            {

                colorVerificado = colorDuplicado;

            }

        return colorVerificado;

    }

    public Color ColorAnterior(Color anterior, Color actual)
    {

        Color colorVerificado = anterior;
        Color colorDuplicado = Color.black;

            if (anterior == actual)
            {

                colorVerificado = colorDuplicado;

            }

        return colorVerificado;
    }
}