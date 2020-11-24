using Domain.Model.Abstractions;
using Domain.Model.Entities;
using Domain.Model.ObjectValues;
using Infra.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aplication
{
    public class InformeService
    {
        private IInformeRepository informeRepository;
        public EntityState EstadoEntidad { private get; set; }

        public InformeService()
        {
            informeRepository = new InformeRepository();
        }

        public async Task<IEnumerable<Informe>> GetInformesAsync()
        {
            return await informeRepository.GetInformesAsync().ConfigureAwait(false);
        }

        public string SaveChanges(Informe informe)
        {
            string mensaje = null;
            try
            {
                switch (EstadoEntidad)
                {
                    case EntityState.Agregado:
                        //ejecutar reglas comerciales / calculos
                        informeRepository.Add(informe);
                        mensaje = "Se agrego correctamente";
                        break;
                    case EntityState.Modificado:
                        informeRepository.Edit(informe);
                        mensaje = "Se modifico correctamente";
                        break;
                    case EntityState.Eliminado:
                        informeRepository.Delete(informe.InformeID);
                        mensaje = "Se elimino correctamente";
                        break;
                }
            }
            catch (Exception ex)
            {
                if (ex is System.Data.SqlClient.SqlException sqlEx && sqlEx.Number == 2627)
                    mensaje = "Registro Duplicado";
                else
                    mensaje = ex.ToString();
            }
            return mensaje;
        }
    }
}
