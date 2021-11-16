using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LanguageU
{
    /// <summary>
    /// Funcion que devuelve un diccionario Ej: <spa, diccionario<ID_Play, Jugar>>
    /// </summary>
    /// <param name="source"></param>
    /// <param name="sheet"></param>
    /// <returns></returns>
    public static Dictionary<Language, Dictionary<string,string>> LoadCodexFromString(string source, string sheet)
    {
        //Creamos una variable del mismo tipo a devolver
        var codex = new Dictionary<Language, Dictionary<string, string>>();

        //Un contador de lineas para saber en donde fallo
        int lineNum = 0;

        //Cortamos los renglones cada vez que encontremos un salto de linea
        string[] rows = sheet.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

        //Bool para saber si estamos en la primer fila
        bool first = true;

        //Diccionario para saber en que posicion esta determinada columna.
        //Ej: <Idioma, 0> - <ID, 1> - <Texto - 2>
        var columnToIndex = new Dictionary<string, int>();

        foreach (var row in rows)
        {
            //Sumamos para saber que estamos en la primer fila
            lineNum++;

            //Separamos por columna al encontrar un ';'
            string[] cells = row.Split(';');

            //Si es la primer linea
            if (first)
            {
                first = false; //Ya sabemos que la siguiente fila no es la primera

                for (int i = 0; i < cells.Length; i++)
                {
                    columnToIndex[cells[i]] = i; //Guardamos el indice de donde se encuentra esa columna que tiene un nombre.
                                                 //En nuestro caso es ID, Idioma, Texto
                }
                continue;
            }

            //Si detectamos que hay una diferencia en las columnas siguientes a la primera,
            //avisamos en console para que sepamos que algo fallo
            if (cells.Length != columnToIndex.Count)
            {
                Debug.Log(string.Format("Parsing CSV file {2} at line {0}, columns {1}, should be 3", lineNum, cells.Length, source));
                continue;
            }

            Debug.Log(columnToIndex["Idioma"].ToString());
            string langName = cells[columnToIndex["Idioma"]]; //Le decimos que tome el valor de la columna
                                                              //que se encuentra en Idioma

            Language lang;

            //Intentamos castear el lenguage de la celda a algun lenguage del ENUM.
            //Si hay un problema lo sabemos en el catch
            try
            {
                lang = (Language)Enum.Parse(typeof(Language), langName);
            }
            catch (Exception e)
            {
                Debug.Log(string.Format("Parsing CSV file {2} at line {0}, invalid language {1}", lineNum, langName, source));
                Debug.Log(e.ToString());
                continue;
            }

            string idName = cells[columnToIndex["ID"]]; //Le decimos que tome el ID correspondiente

            string text = cells[columnToIndex["Texto"]]; //Le decimos que tome el texto correspondiente

            //Si el diccionario no contiene ese idioma
            if (!codex.ContainsKey(lang))
            {
                codex[lang] = new Dictionary<string, string>(); //Lo creamos
            }

            codex[lang][idName] = text; //Le decimos al diccionario que en "X" lenguaje,
                                        //utilizando "Y" ID,
                                        //vamos a guardar "Z" texto
        }

        return codex;
    }
}
