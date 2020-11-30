﻿using Entidades;
using Enumeraciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

// alt+shift+ ` para elegir todas las coincidencias editar.incluirsimbolosdeinsercionentodaslascoincidencias
// TODO Hacer toda la capa de datos.
// TODO Poner correctamente scope de las propiedades de las clases.
// TODO Hacer todos los metodos de la capa de datos.
// TODO Implementar validacion en la capa de datos.
// TODO Modificar la propiedad Horario para que sea correcta. Solucionar problema de que en la base de datos se almacena el numero de la enumeracion pero no el nombre.
// TODO Verificar como conviene eliminar un registro, ya que el siguiente registro que se agrega no ocupa el mismo primary key(id).
// TODO Implementar SQLite.
// TODO Resolver problema de los metodos no devuelven los valores de carrera y queda como null.
// TODO Realizar capa de dato en DataBaseFirst
// Para mapear base de datos
// Scaffold-DbContext "Server=.\SQLExpress;Database=Alumnos;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir DatabaseFirstModel
// select * from Alumnos;
// select * from Asignaturas;
// select * from ListadoAsignaturas;
// select * from Carreras;
// select * from ListadoCarreras;
// select * from Facultades;
// select * from Notas;

namespace Datos
{
    public static class Alumno
    {
        public static Entidades.AlumnosContext db = new AlumnosContext();
#nullable enable
        public static Entidades.Alumnos ListarUno(int? alumnoID = null, string ? nombre = null, string? apellido = null, int? edad = null, int? dni = null)
        {
            if (alumnoID != null)
            {
                return db.Alumnos.Where(a => a.AlumnoId == alumnoID).SingleOrDefault();
            }
            else if (nombre != null)
            {
                return db.Alumnos.Where(a => a.Nombre == nombre).FirstOrDefault();
            }
            else if (apellido != null)
            {
                return db.Alumnos.Where(a => a.Apellido == apellido).FirstOrDefault();
            }
            else if (edad != null)
            {
                return db.Alumnos.Where(a => a.Edad == edad).FirstOrDefault();
            }
            return db.Alumnos.Where(a => a.Dni == dni).FirstOrDefault();
        }

        public static List<Entidades.Alumnos> ListarVarios(int? alumnoID = null, string? nombre = null, string? apellido = null, int? edad = null, int? dni = null)
        {
            if (alumnoID != null)
            {
                return db.Alumnos.Where(a => a.AlumnoId == alumnoID).ToList();
            }
            else if (nombre != null)
            {
                return db.Alumnos.Where(a => a.Nombre == nombre).ToList();
            }
            else if (apellido != null)
            {
                return db.Alumnos.Where(a => a.Apellido == apellido).ToList();

            }
            else if (edad != null)
            {
                return db.Alumnos.Where(a => a.Edad == edad).ToList();

            }
            return db.Alumnos.Where(a => a.Dni == dni).ToList();

        }
#nullable disable
        public static List<Entidades.Alumnos> ListarTodos()
        {
            return db.Alumnos.ToList();
        }

        public static void Agregar(Entidades.Alumnos alumno)
        {
            db.Alumnos.Add(entity: alumno);
            db.SaveChanges();
        }

        public static void Editar(Entidades.Alumnos alumno)
        {
            Entidades.Alumnos unAlumno = db.Alumnos.Where(a => a.AlumnoId == alumno.AlumnoId).SingleOrDefault();

            if (unAlumno != null)
            {
                unAlumno.Nombre = alumno.Nombre;
                unAlumno.Apellido = alumno.Apellido;
                unAlumno.Edad = alumno.Edad;
                unAlumno.Dni = alumno.Dni;
                db.SaveChanges();
            }
            else
            {
                Console.WriteLine("\nNo hay resultados con ese ID");
            }
        }

        public static void Eliminar(int id)
        {
            db.Alumnos.Remove(db.Alumnos.Find(id));
            db.SaveChanges();
        }
    }
}