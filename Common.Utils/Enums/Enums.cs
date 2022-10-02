using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Utils.Enums
{
    public class Enums
    {

        public enum TypeState
        {
            //Usuario
            Vendida = 1,
            Alquilada = 2,
            Encargada = 3,
            Produccion = 4,

        }
        public enum Genders
        {
            //Usuario
            Ciencia_Ficcion = 1,
            Aventuras = 2,
            Comedia  = 3,
            Drama = 4,
            Terror = 5,
            Suspenso = 6,
            Amor = 7,
            Romance= 8,
            Historia=9,
            Fantasia=10,    



        }
        public enum Director
        {
            GoreVerbinski = 1,
           
        }

        public enum Movies
        {
            Piratas = 1,
           
        }
        public enum TypePermission
        {
            Usuario = 1,
            Roles = 2,
            Permisos = 3,
            Movies = 4,
            Directores = 5,
            Generos = 6,
            Estados = 7
        }
        public enum Permission
        {
            //Usuarios
            CrearUsuarios = 1,
            ActualizarUsuarios = 2,
            EliminarUsuarios = 3,
            ConsultarUsuarios = 4,

            //Roles
            ActualizarRoles = 5,
            ConsultarRoles = 6,

            //Permisos
            ActualizarPermisos = 7,
            ConsultarPermisos = 8,
            DenegarPermisos = 9,

            //Estados
            ConsultarEstados = 10,
            ActualizarEstados = 11,

            //Movies
            CrearPeliculas = 12,
            ActualizarPeliculas = 13,
            EliminarPeliculas = 14,
            ConsultarPeliculas = 15,

            //Director
            CrearDirector = 16,
            ActualizarDirector = 17,
            EliminarDirector = 18,
            ConsultarDirectores = 19,

            //Generos
            ConsultarGeneros = 20,
            ActualizarGeneros = 21,
            CrearGenero =22,
         
        }

        public enum RolUser
        {
            Administrador = 1,
            Estandar = 2
        }
    }
}
