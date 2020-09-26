﻿using ClasesNetCore;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Xml;

namespace ConsolaNetCore
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Programa de gestion de notas y asistencia de alumnos

            //Hacer un programa que pida el ingreso de una lista de alumnos con sus respectivas notas de:
            //1er parcial, 2do parcial, recuperatorios y final.
            //Indicar si se promociona o reprueba. Cada uno de los examanes y materia.
            //Se promociona con nota minima total 13, cada parcial se aprueba con 4, la maxima discrepancia es un parcial 4 y otro parcial 9 para promocionar.
            //Se pueden recuperar los 2 parciales.
            //Promedio menor a 13 se va a final. Se necesitan tener los 2 parciales aprobados para ir a final.
            //TODO agregar mas consignas

            //--HARDCODEADO--

            //inicializando lista de alumnos

            int parcial1, parcial2, final, total;
            string nombre, apellido;
            bool parcial1Reprobado = false, parcial2Reprobado = false;
            Random rnd = new Random();

            List<string> alumnos = new List<string>();

            //Console.WriteLine("\nQue desea hacer? Elija la opcion deseada:");
            //Console.WriteLine("\n1 = Modo Automatico - 2 = Modo Manuel - 3 = Salir");

            //int respuesta = Convert.ToInt32(Console.ReadLine());

            //switch (respuesta)
            //{
            //    case 1:
            //        break;
            //    case 2:
            //        break;
            //    case 3:
            //        break;
            //    default:
            //        break;
            //}

            //TODO ingreso de datos manual, no hardcodeado

            Console.WriteLine("\nPrograma de gestion de notas y asistencia de alumnos\n\nA continuacion se le pedira agregar los alumnos y sus notas");

            Console.WriteLine("\nIngresar alumnos");

            Console.WriteLine("\nCuantos alumnos quiere ingresar? (0-100)");
            int ingresados = Convert.ToInt32(Console.ReadLine());

            for (int i = 1; i <= ingresados; i++)
            {
                Console.WriteLine($"\nIngrese el nombre de su alumno Nº {i}:");
                nombre = Console.ReadLine();
                Console.WriteLine($"\nIngrese el apellido de su alumno Nº {i}:");
                apellido = Console.ReadLine();

                alumnos.Add($"Nº {i} - {nombre} {apellido}");
                Console.Clear();
            }
            
            foreach (var alumno in alumnos)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nSu alumno es: {alumno}");
            }

            Console.ReadKey();
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nIngresando notas...");

            //ingresando notas del alumno

            foreach (var alumno in alumnos)
            {
                parcial1Reprobado = false;
                parcial2Reprobado = false;
                parcial1 = 0;
                parcial2 = 0;
                total = 0;
                final = 0;

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n---NOTAS DEL ALUMNO {alumno}---");
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine("\nIngrese la nota del primer parcial:");
                parcial1 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("\nIngrese la nota del segundo parcial:");
                parcial2 = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine($"\nLa nota del primer parcial de su alumno {alumno} es: {parcial1}");
                Console.WriteLine($"\nLa nota del segundo parcial de su alumno {alumno} es: {parcial2}");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n----------------------");
                Console.ForegroundColor = ConsoleColor.White;

                //se verifica si debe recuperar el parcial
                if (parcial1 < 4)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\nEl alumno {alumno} debe recuperar el primer parcial");
                    Console.ForegroundColor = ConsoleColor.White;
                    parcial1Reprobado = true;
                }
                if (parcial2 < 4)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\nEl alumno {alumno} debe recuperar el segundo parcial");
                    Console.ForegroundColor = ConsoleColor.White;
                    parcial2Reprobado = true;
                }


                //se recupera el parcial
                if (parcial1Reprobado == true)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n---INSTANCIA DE RECUPERATORIO---");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"\nEl {alumno} recupera el primer parcial");
                    Console.WriteLine("\nIngrese la nota del recuperatorio:");
                    parcial1 = Convert.ToInt32(Console.ReadLine());

                    if (parcial1 >= 4)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"\nEl {alumno} aprobo el recuperatorio del primer parcial");
                        parcial1Reprobado = false;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\n--------------------------------");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"\nEl {alumno} reprobo el recuperatorio del primer parcial");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\n--------------------------------");
                        Console.ForegroundColor = ConsoleColor.White;

                    }
                }

                if (parcial2Reprobado == true)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n---INSTANCIA DE RECUPERATORIO---");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"\nEl {alumno} recupera el segundo parcial");
                    Console.WriteLine("\nIngrese la nota del recuperatorio:");
                    parcial2 = Convert.ToInt32(Console.ReadLine());

                    if (parcial2 >= 4)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"\nEl {alumno} aprobo el recuperatorio del segundo parcial");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\n--------------------------------");
                        Console.ForegroundColor = ConsoleColor.White;

                        parcial2Reprobado = false;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"\nEl {alumno} reprobo el recuperatorio del segundo parcial");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\n--------------------------------");
                        Console.ForegroundColor = ConsoleColor.White;

                    }
                }

                if (parcial1Reprobado == true || parcial2Reprobado == true)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n---NOTAS DEL ALUMNO---");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"\nLa nota del primer parcial de su alumno {alumno} es: {parcial1}");
                    Console.WriteLine($"\nLa nota del segundo parcial de su alumno {alumno} es: {parcial2}");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n----------------------");
                    Console.ForegroundColor = ConsoleColor.White;
                }


                total = parcial1 + parcial2;

                //indicando si promociono la materia
                if (total >= 13)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"\nEl alumno {alumno} promociono con promedio {total / 2}!");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (parcial1Reprobado == false && parcial2Reprobado == false)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\nEl {alumno} obtuvo {total}, no alcanzo la nota para promocionar (13), va a instancia de final");
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.WriteLine("\nIngrese la nota del final:");
                    final = Convert.ToInt32(Console.ReadLine());

                    if (final >= 4)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\n---INSTANCIA DE FINAL---");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine($"\nLa nota del final del alumno {alumno} es: {final}");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\n-------------------------");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"\nPromociono con promedio {final}!");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\n---INSTANCIA DE FINAL---");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine($"\nLa nota del final del alumno {alumno} es: {final}");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\n-------------------------");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"\nSu alumno {alumno} debe recursar la materia");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\nSu alumno {alumno} no tiene los 2 parciales aprobados con minimo (4) para ingresar a instancia de final\ndebe recursar la materia");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.ReadKey();
                Console.Clear();
            }

            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("\nFin del programa\n\nPresione cualquier tecla para finalizar");

            Console.ReadKey();
        }
    }
}
