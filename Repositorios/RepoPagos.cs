using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using System.Data;
using System.Data.SqlClient;

namespace Repositorios
{
    public class RepoPagos : IRepositorio<FormaDePago>
    {
        public bool Alta(FormaDePago obj)
        {
            if (obj == null)
                return false;

            Conexion con = new Conexion();
            Context db = new Context(con.getConectionString());
            try
            {
                if (obj is Cuponera)
                {
                    Cuponera cup = (Cuponera)obj;
                    Pago pago = new Pago
                    {
                        CedulaSocio = obj.Socio.Cedula,
                        Fecha = DateTime.Now.Date,
                        DescuentoPL = 0,
                        AntiguedadPL = 0,
                        PrecioPL = 0,
                        DescuentoC = cup.CalcularDescAplicado(),
                        CantActividadesC = cup.CantActividades,
                        PrecioTotalC = cup.CalcularCosto()
                    };
                    db.Pagos.Add(pago);
                }
                else if (obj is PaseLibre)
                {
                    PaseLibre pas = (PaseLibre)obj;
                    Pago pago = new Pago
                    {
                        CedulaSocio = obj.Socio.Cedula,
                        Fecha = DateTime.Now.Date,
                        DescuentoPL = pas.CalcularDescAplicado(),
                        AntiguedadPL = pas.Antiguedad,
                        PrecioPL = pas.CalcularCosto(),
                        DescuentoC = 0,
                        CantActividadesC = 0,
                        PrecioTotalC = 0
                    };
                    db.Pagos.Add(pago);
                }
                
                db.SaveChanges();
                return true;

            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                db.Dispose();
            }
        }

        public bool Baja(int id) //NO SE IMPLEMENTA
        {
            throw new NotImplementedException();
        }

        public FormaDePago BuscarPorId(int id) //NO SE IMPLEMENTA
        {
            throw new NotImplementedException();
        }

        public bool Modificacion(FormaDePago obj) //NO SE IMPLEMENTA
        {
            throw new NotImplementedException();
        }

        public List<FormaDePago> TraerTodos() //NO SE IMPLEMENTA
        {
            throw new NotImplementedException();
        }

        public bool VerificarMensualidad(Socio socio)
        {
            Conexion con = new Conexion();
            Context db = new Context(con.getConectionString());
            bool retorno = false;
            try
            {
                Pago pago = db.Pagos
                    .Where(pa => pa.CedulaSocio == socio.Cedula)
                    .Where(pa => pa.CedulaSocio == socio.Cedula)
                    .Where(pa => pa.Fecha.Month == DateTime.Now.Month)
                    .Where(pa => pa.Fecha.Year == DateTime.Now.Year).SingleOrDefault();

                if (pago != null) retorno = true;

                return retorno;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                db.Dispose();
            }
        }
        public IEnumerable<PagoSocio> ListarPagosPorMesYAnio(int month, int year) //FALTA OBTENER NOMBRE SOCIO
        {
            IEnumerable<PagoSocio> listaPagosSocio = new List<PagoSocio>();
            //PagoSocio listaPagosSocio = new PagoSocio();

            Conexion con = new Conexion();
            Context db = new Context(con.getConectionString());
            try
            {

                var listaPagosSocioAux =
                  from Pagos in db.Pagos
                  join Socios in db.Socios
                  on Pagos.CedulaSocio equals Socios.Cedula
                  where Pagos.Fecha.Month == month
                  where Pagos.Fecha.Year == year
                  select new PagoSocio
                  {
                      NombreSocio = Socios.Nombre,
                      CedulaSocio = Pagos.CedulaSocio,
                      Fecha = Pagos.Fecha,
                      DescuentoPL = Pagos.DescuentoPL,
                      DescuentoC = Pagos.DescuentoC,
                      PrecioPL = Pagos.PrecioPL,
                      PrecioTotalC = Pagos.PrecioTotalC
                  };

                listaPagosSocio = (IEnumerable<PagoSocio>)listaPagosSocioAux;
                return listaPagosSocio;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                db.Dispose();
            }
            return listaPagosSocio;
        }
    }
}
