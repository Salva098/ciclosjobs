
using AutoMapper;
using ciclojobs.BL.Contracts;
using ciclojobs.DAL.Entities;
using ciclojobs.DAL.Repositories.Contracts;
using ciclosjobs.Core.DTO.ProvinciasDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ciclojobs.BL.Implementations
{
    public class ProvinciasBL : IProvinciasBL
    {
        public IMapper mapper { get; set; }
        public IProvinciasRepository ProvinciasRepository { get; set; }
        public ProvinciasBL(IProvinciasRepository ProvinciasRepository, IMapper mapper)
        {
            this.ProvinciasRepository = ProvinciasRepository;
            this.mapper = mapper;
        }
        public ProvinciasDTO ObtenerProvincia(int id)
        {
            return mapper.Map<Provincias, ProvinciasDTO>(ProvinciasRepository.ObtenerProvincia(id)); 
            
        }

        public List<ProvinciasDTO> ObtenerTodoProvincia()
        {
            return mapper.Map<List<Provincias>, List<ProvinciasDTO>>(ProvinciasRepository.ObtenerTodoProvincia());
        }
    }
}
