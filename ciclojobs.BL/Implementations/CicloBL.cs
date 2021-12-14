using AutoMapper;
using ciclojobs.BL.Contracts;
using ciclojobs.DAL.Entities;
using ciclojobs.DAL.Repositories.Contracts;
using ciclosjobs.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ciclojobs.BL.Implementations
{
    public class CicloBL : ICicloBL
    {
        public IMapper mapper { get; set; }
        public ICicloRepository CicloRepository { get; set; }
        public CicloBL(ICicloRepository CicloRepository, IMapper mapper)
        {
            this.CicloRepository = CicloRepository;
            this.mapper = mapper;
        }
        public CicloDTO ObtenerCiclo(int id)
        {
           return mapper.Map<Ciclo, CicloDTO > (CicloRepository.ObtenerCiclo(id));

        }
    }
}
