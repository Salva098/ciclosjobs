using AutoMapper;
using ciclojobs.BL.Contracts;
using ciclojobs.DAL.Entities;
using ciclojobs.DAL.Repositories.Contracts;
using ciclosjobs.Core.DTO.FamiliaProfeDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ciclojobs.BL.Implementations
{
    public class TipoCicloBL : ITipoCicloBL
    {

        public IMapper mapper { get; set; }
        public ITipoCicloRepository TipoCicloRepository { get; set; }

        public TipoCicloBL(IMapper mapper, ITipoCicloRepository TipoCicloRepository)
        {
            this.mapper = mapper;
            this.TipoCicloRepository = TipoCicloRepository;
               
        }
        public List<TipoCicloDTO> getAllTiposCiclos()
        {
            return mapper.Map<List<TipoCiclo>, List<TipoCicloDTO>>(this.TipoCicloRepository.getAllTiposCiclos());

        }
    }
}
