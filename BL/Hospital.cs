using DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Hospital
    {
        public static ML.Hospital GetAllLinQ()
        {
            ML.Hospital hospital = new ML.Hospital();

            try
            {
                using (DL.SgomezHospitalContext context = new DL.SgomezHospitalContext())
                {
                    var query = (from Hospital in context.Hospitals
                                 join Especialidad in context.Especialidads on Hospital.IdEspecialidad equals Especialidad.IdEspecialidad
                                 select new
                                 {
                                     IdHospital = hospital.IdHospital,
                                     Nombre = hospital.Nombre,
                                     Direccion = hospital.Direccion,
                                     AñoDeConstruccion = hospital.AñoDeConstruccion,
                                     capacidad = hospital.capacidad,
                                     IdEspecialidad = hospital.IdEspecialidad,
                                     
                                 }).ToList();

                    if (query != null)
                    {
                        hospital.Hospitals = new List<ML.Hospital>();
                        foreach (var registro in query)
                        {
                            ML.Hospital hospital1 = new ML.Hospital();

                            hospital1.IdHospital = registro.IdHospital;
                            hospital1.Nombre = registro.Nombre;
                            hospital1.Direccion = registro.Direccion;
                            hospital1.AñoDeConstruccion = registro.AñoDeConstruccion;
                            hospital1.capacidad = registro.capacidad;
                            hospital1.Especialidad = new ML.Especialidad();
                            hospital1.Especialidad.IdEspecialidad = registro.IdEspecialidad;


                            hospital.Hospitals.Add(hospital1 );
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return hospital;
        }
    }
}
