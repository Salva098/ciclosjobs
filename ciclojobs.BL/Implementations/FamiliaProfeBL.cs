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
    public class FamiliaProfeBL : IFamiliaProfeBL
    {
        public IMapper mapper { get; set; }
        public IFamiliaProfeRepository FamilaProfeRepository { get; set; }


        public FamiliaProfeBL(IFamiliaProfeRepository FamilaProfeRepository, IMapper mapper)
        {
            this.FamilaProfeRepository = FamilaProfeRepository;
            this.mapper = mapper;
           

        }
        public List<FamiliaProfeDTO> getAllFamiliaProfe()
        {
            return mapper.Map<List<FamiliaProfe>, List<FamiliaProfeDTO>>(this.FamilaProfeRepository.getAllFamiliaProfe());
        }

        public List<FamiliaProfeDTO> getFamiliaProfe(int tipoCiclo)
        {
            return mapper.Map<List<FamiliaProfe>, List<FamiliaProfeDTO>>(this.FamilaProfeRepository.getFamiliaProfe(tipoCiclo));

        }
    }
}
