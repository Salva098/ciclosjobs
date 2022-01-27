using ciclosjobs.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ciclosjobs.Core.Security
{
    public interface IJwtBearer
    {
        public string GenerateJWTTokenAlumno(AlumnoDTO alumno);
        public string GenerateJWTTokenEmpresa(EmpresaDTO empresa);
        public int GetEmpresaIdFromToken(string token);
        public int GetAlumnoIdFromToken(string token);
    }
}
