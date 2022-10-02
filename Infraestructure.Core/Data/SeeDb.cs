using Common.Utils.Enums;
using Infraestructure.Entity.Models.Master;
using Infraestructure.Entity.Models.Movies;
using Infraestructure.Entity.Models.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Core.Data
{
    public class SeeDb
    {
        private readonly DataContext _context;
        #region Builder
        public SeeDb(DataContext context)
        {
            _context = context;
        }

        #endregion

        public async Task ExecSeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();

            await CheckTypePermissionAsync();
            await CheckPermissionAsync();
            await CheckRolAsync();
            await CheckRolPermissonAsync();

            await CheckTypeStateAsync();
            await CheckGenderAsync();
            await CheckDirectorAsync();
            await CheckMoviesAsync();
            await CheckRolUsersAsync();

         


        }
        private async Task CheckTypeStateAsync()
        {
            if (!_context.TypeStateEntity.Any())
            {
                _context.TypeStateEntity.AddRange(new List<TypeStateEntity>
                {
                    new TypeStateEntity
                    {
                        IdTypeState=(int)Enums.TypeState.Vendida,
                        TypeState="Vendida"
                    },
                    new TypeStateEntity
                    {
                        IdTypeState=(int)Enums.TypeState.Alquilada,
                        TypeState ="Alquilada"
                    },
                    new TypeStateEntity
                    {
                        IdTypeState=(int)Enums.TypeState.Encargada,
                        TypeState ="Encargada"
                    },new TypeStateEntity
                    {
                        IdTypeState=(int)Enums.TypeState.Produccion,
                        TypeState ="Produccion"
                    }
                });
                await _context.SaveChangesAsync();
            }
        }
        private async Task CheckRolUsersAsync()
        {
            if (!_context.RolUserEntity.Any())
            {
                _context.RolUserEntity.AddRange(new List<RolUserEntity>
                    {
                    new RolUserEntity()
                    {
                            IdRol = (int)Enums.RolUser.Estandar,
                            UserEntity = new UserEntity()
                        {
                            Name = "Magnus",
                            LastName = "Lopez",
                            Email = "magnus@gmail.com",
                            Password = "123456"
                        }
                    },

                    new RolUserEntity()
                    {
                            IdRol = (int)Enums.RolUser.Administrador,
                            UserEntity = new UserEntity()
                            {
                                Name = "Camila",
                                LastName = "Rodriguez",
                                Email = "carepa@gmail.com",
                                Password = "123456"
                            }
                    },
                    });

                await _context.SaveChangesAsync();
            }
        }
        private async Task CheckTypePermissionAsync()
        {
            if (!_context.TypePermissionEntity.Any())
            {
                _context.TypePermissionEntity.AddRange(new List<TypePermissionEntity>
                {
                      new TypePermissionEntity
                      {
                        IdTypePermission=(int)Enums.TypePermission.Usuario,
                        TypePermission="Usuarios"

                      },
                       new TypePermissionEntity
                       {
                        IdTypePermission=(int)Enums.TypePermission.Roles,
                        TypePermission="Roles"

                       },
                      new TypePermissionEntity
                      {
                        IdTypePermission=(int)Enums.TypePermission.Permisos,
                        TypePermission="Permisos"

                      },
                      new TypePermissionEntity
                      {
                        IdTypePermission=(int)Enums.TypePermission.Movies,
                        TypePermission="Biblioteca"

                      },
                      new TypePermissionEntity
                      {
                        IdTypePermission=(int)Enums.TypePermission.Directores,
                        TypePermission="AutorS"

                      },
                       new TypePermissionEntity
                      {
                        IdTypePermission=(int)Enums.TypePermission.Estados,
                        TypePermission="AutorS"

                      },
                        new TypePermissionEntity
                      {
                        IdTypePermission=(int)Enums.TypePermission.Generos,
                        TypePermission="AutorS"

                      },
                });
                await _context.SaveChangesAsync();
            }
        }
        private async Task CheckPermissionAsync()
        {
            if (!_context.PermissionEntity.Any())
            {
                _context.PermissionEntity.AddRange(new List<PermissionEntity>
                {
                    //Usuarios
                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.CrearUsuarios,
                        IdTypePermission=(int)Enums.TypePermission.Usuario,
                        Permission="Crear Usuarios",
                        Description="Crear Usuarios al Sistemas"
                    },

                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.ActualizarUsuarios,
                        IdTypePermission=(int)Enums.TypePermission.Usuario,
                        Permission="Actualizar Usuarios",
                        Description="Actualizar datos de un usuarios en el sistema"
                    },

                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.EliminarUsuarios,
                        IdTypePermission=(int)Enums.TypePermission.Usuario,
                        Permission="Eliminar Usuarios",
                        Description="Eliminar un usuario del sistema"
                    },

                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.ConsultarUsuarios,
                        IdTypePermission=(int)Enums.TypePermission.Usuario,
                        Permission="Consultar Usuarios",
                        Description="Consulta todos los usuarios"
                    },

                    //Roles
                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.ActualizarRoles,
                        IdTypePermission=(int)Enums.TypePermission.Roles,
                        Permission="Actualizar Roles",
                        Description="Actualizar datos de los roles en el sistema"
                    },

                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.ConsultarRoles,
                        IdTypePermission=(int)Enums.TypePermission.Roles,
                        Permission="Consultar Roles",
                        Description="Consultar Roles del sistema"
                    },

                    //Permisos
                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.ActualizarPermisos,
                        IdTypePermission=(int)Enums.TypePermission.Permisos,
                        Permission="Actualizar Permisos",
                        Description="Actualizar datos de un permiso en el sistema"
                    },

                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.ConsultarPermisos,
                        IdTypePermission=(int)Enums.TypePermission.Permisos,
                        Permission="Consultar Permisos",
                        Description="Consultar Permisos del sistema"
                    },

                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.DenegarPermisos,
                        IdTypePermission=(int)Enums.TypePermission.Permisos,
                        Permission="Denegar Permisos",
                        Description="Denegar Permisos a un rol del sistema"
                    },

                    //Estados
                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.ConsultarEstados,
                        IdTypePermission=(int)Enums.TypePermission.Estados,
                        Permission="Consultar Estado",
                        Description="Consultar los estados del sistema"
                    },

                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.ActualizarEstados,
                        IdTypePermission=(int)Enums.TypePermission.Estados,
                        Permission="Actualizar Estado",
                        Description="Actualizar los estados del sistema"
                    },

                    //Movies
                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.CrearPeliculas,
                        IdTypePermission=(int)Enums.TypePermission.Movies,
                        Permission="Insertar Películas",
                        Description="Insertar una película"
                    },

                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.ActualizarPeliculas,
                        IdTypePermission=(int)Enums.TypePermission.Movies,
                        Permission="Actualizar Películas",
                        Description="Actualizar la información de las películas"
                    },

                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.EliminarPeliculas,
                        IdTypePermission=(int)Enums.TypePermission.Movies,
                        Permission="Eliminar Películas",
                        Description="Eliminar Películas"
                    },

                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.ConsultarPeliculas,
                        IdTypePermission=(int)Enums.TypePermission.Movies,
                        Permission="Consultar Películas",
                        Description="Consultar información de una película"
                    },

                    //Directores
                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.CrearDirector,
                        IdTypePermission=(int)Enums.TypePermission.Directores,
                        Permission="Crear Director",
                        Description="Crear Director"
                    },

                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.ActualizarDirector,
                        IdTypePermission=(int)Enums.TypePermission.Directores,
                        Permission="Actualizar Director",
                        Description="Actualizar inforamcion del Director"
                    },

                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.EliminarDirector,
                        IdTypePermission=(int)Enums.TypePermission.Directores,
                        Permission="Eliminar Director",
                        Description="Eliminar Director"
                    },

                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.ConsultarDirectores,
                        IdTypePermission=(int)Enums.TypePermission.Directores,
                        Permission="Consultar Director",
                        Description="Consultar los Directores"
                    },

                    //Genero de peliculas 
                         new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.ConsultarGeneros,
                        IdTypePermission=(int)Enums.TypePermission.Generos,
                        Permission="Consultar  Género",
                        Description="Consultar los géneros de las películas"
                    },
                         new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.ActualizarGeneros,
                        IdTypePermission=(int)Enums.TypePermission.Generos,
                        Permission="Actualizar  Género",
                        Description="Actualizar los géneros de las películas"
                    },
                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.CrearGenero,
                        IdTypePermission=(int)Enums.TypePermission.Generos,
                        Permission="Crear Género de Película",
                        Description="Crear un género de una película"
                    },

               

                });
                await _context.SaveChangesAsync();
            }
        }
        private async Task CheckRolAsync()
        {
            if (!_context.RolEntity.Any())
            {
                _context.RolEntity.AddRange(new List<RolEntity>
                {
                    new RolEntity
                    {
                        IdRol=(int)Enums.RolUser.Administrador,
                        Rol="Administrador"
                    },
                     new RolEntity
                    {
                        IdRol=(int)Enums.RolUser.Estandar,
                        Rol="Estandar"
                    }
                });

                await _context.SaveChangesAsync();
            }
        }
        private async Task CheckRolPermissonAsync()
        {
            if (!_context.RolPermissionEntity.Where(x => x.IdRol == (int)Enums.RolUser.Administrador).Any())
            {
                var rolesPermisosAdmin = _context.PermissionEntity.Select(x => new RolPermissionEntity
                {
                    IdRol = (int)Enums.RolUser.Administrador,
                    IdPermission = x.IdPermission
                }).ToList();

                _context.RolPermissionEntity.AddRange(rolesPermisosAdmin);
                _context.RolPermissionEntity.AddRange(new List<RolPermissionEntity>
                    {

                        new RolPermissionEntity
                        {
                        IdRol = (int)Enums.RolUser.Estandar,
                        IdPermission = (int)Enums.Permission.ConsultarPeliculas
                        },

                        new RolPermissionEntity
                        {
                        IdRol = (int)Enums.RolUser.Estandar,
                        IdPermission = (int)Enums.Permission.ConsultarDirectores
                        },

                        new RolPermissionEntity
                        {
                        IdRol = (int)Enums.RolUser.Estandar,
                        IdPermission = (int)Enums.Permission.ConsultarGeneros
                        },
                        new RolPermissionEntity
                        {
                        IdRol = (int)Enums.RolUser.Estandar,
                        IdPermission = (int)Enums.Permission.ConsultarEstados
                        }

                    });

                await _context.SaveChangesAsync();

            }

        }
     
        private async Task CheckGenderAsync()
        {
            if (!_context.GenderEntity.Any())
            {
                _context.GenderEntity.AddRange(new List<GenderEntity>
                {
                    new GenderEntity
                    {
                        IdGender=(int)Enums.Genders.Ciencia_Ficcion,
                        Gender = "Ciencia Ficción"


                    },
                    new GenderEntity
                    {
                        IdGender=(int)Enums.Genders.Aventuras,
                        Gender = "Aventuras"

                    },
                    new GenderEntity
                    {
                        IdGender=(int)Enums.Genders.Comedia,
                        Gender = "Comedia"

                    },new GenderEntity
                    {
                        IdGender=(int)Enums.Genders.Drama,
                        Gender = "Drama"

                    },
                    new GenderEntity
                    {
                        IdGender=(int)Enums.Genders.Terror,
                        Gender= "Terror"
                    },
                    new GenderEntity
                    {
                        IdGender=(int)Enums.Genders.Suspenso,
                        Gender= "Suspenso"
                    },
                    new GenderEntity
                    {
                        IdGender=(int)Enums.Genders.Amor,
                        Gender= "Amor"
                    },
                    new GenderEntity
                    {
                        IdGender=(int)Enums.Genders.Romance,
                        Gender= "Romance"
                    },
                    new GenderEntity
                    {
                        IdGender=(int)Enums.Genders.Historia,
                        Gender= "Historia"
                    },new GenderEntity
                    {
                        IdGender=(int)Enums.Genders.Fantasia,
                        Gender= "Fantasia"
                    }
                });
                await _context.SaveChangesAsync();
            }
        }
        private async Task CheckDirectorAsync()
        {
            if (!_context.DirectorEntity.Any())
            {
                _context.DirectorEntity.AddRange(new List<DirectorEntity>
                {
                    new DirectorEntity
                    {
                        IdDirector=(int)Enums.Director.GoreVerbinski,
                        Name = "Gore",
                        LastName="Verbinski"
                    }
                 
                });
                await _context.SaveChangesAsync();
            }
        }
        private async Task CheckMoviesAsync()
        {
            if (!_context.MoviesEntity.Any())
            {
                _context.MoviesEntity.AddRange(new List<MoviesEntity>
                {
                    new MoviesEntity
                    {
                        IdMovie=(int)Enums.Movies.Piratas,
                        Title="Los Piratas del Caribe",
                        Sipnosis=" ",
                        IdDirector=(int)Enums.Director.GoreVerbinski,
                        IdGender=(int)Enums.Genders.Aventuras,
                        Anio="2003",
                        Pais ="Haití",
                        ProtagonistMain="Jack Sparrow",
                        Duration="2 Horas 30 mts",
                        IdTypeState=(int)Enums.TypeState.Vendida,

                    },
                   
                });
                await _context.SaveChangesAsync();
            }
        }
    }
}
