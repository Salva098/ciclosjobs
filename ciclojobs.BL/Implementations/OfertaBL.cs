using AutoMapper;
using ciclojobs.BL.Contracts;
using ciclojobs.DAL.Entities;
using ciclojobs.DAL.Repositories.Contracts;
using ciclosjobs.Core.DTO;
using ciclosjobs.Core.Security;
using System;
using System.Collections.Generic;
using System.Text;

namespace ciclojobs.BL.Implementations
{
    public class OfertaBL : IOfertaBL
    {
        public IMapper mapper { get; set; }
        public IOfertasRepository OfertasRepository { get; set; }

        public ICicloRepository cicloRepository { get; set; }
        public IEmpresaRepository EmpresaRepository { get; set; }

        public OfertaBL(IOfertasRepository OfertasRepository, IMapper mapper, ICicloRepository cicloRepository, IEmpresaRepository EmpresaRepository)
        {
            this.OfertasRepository = OfertasRepository;
            this.mapper = mapper;
            this.cicloRepository = cicloRepository;
            this.EmpresaRepository = EmpresaRepository;

        }

        public bool crearOferta(OfertaDTORegistro ofertadto)
        {
            var oferta = mapper.Map<OfertaDTORegistro, Ofertas>(ofertadto);
            ICollection<Ciclo> ciclos = new List<Ciclo>();
            var idsciclos = ofertadto.ciclo;
            foreach (var item in idsciclos)
            {
                int ids = item.id;
                var ciclo = cicloRepository.ObtenerCiclo(ids);
                ciclos.Add(ciclo);
            }
            oferta.ciclo = ciclos;
            var empresa = EmpresaRepository.ObtenerEmpresa(ofertadto.idempresas);
            oferta.empresas = empresa;
            if (!this.OfertasRepository.existOfertas(oferta))
            {
                return this.OfertasRepository.crearOfertas(oferta);

            }
            else
            {
                return false;
            }
        }

        public OfertaDTO obtenerOferta(int ofertaid)
        {
            return mapper.Map<Ofertas, OfertaDTO>(this.OfertasRepository.obtenerOfertas(ofertaid));
        }

        public List<OfertaDTO> obtenerTodosOferta()
        {
            return mapper.Map< List<Ofertas>, List<OfertaDTO>>(this.OfertasRepository.obtenerTodosOfertas());

        }

        public bool eliminarOferta(OfertaDTORegistro ofertadto)
        {
            var oferta = mapper.Map<OfertaDTORegistro, Ofertas>(ofertadto);
            ICollection<Ciclo> ciclos = new List<Ciclo>();
            var idsciclos = ofertadto.ciclo;
            foreach (var item in idsciclos)
            {
                int ids = item.id;
                var ciclo = cicloRepository.ObtenerCiclo(ids);
                ciclos.Add(ciclo);
            }
            oferta.ciclo = ciclos;
            var empresa = EmpresaRepository.ObtenerEmpresa(ofertadto.idempresas);
            oferta.empresas = empresa;
            if (this.OfertasRepository.existOfertas(oferta))
            {
                return OfertasRepository.eliminarOfertas(oferta.id);
            }
            else
            {
                return false;
            }
        }

        public bool actualizarOferta(OfertaDTOUpdate ofertadto)
        {
            var oferta = mapper.Map<OfertaDTOUpdate, Ofertas>(ofertadto);


            ICollection<Ciclo> ciclos = new List<Ciclo>();
            var idsciclos = ofertadto.ciclo;
            foreach (var item in idsciclos)
            {
                int ids = item.id;
                var ciclo = cicloRepository.ObtenerCiclo(ids);
                ciclos.Add(ciclo);
            }
            oferta.ciclo = ciclos;
            var empresa = EmpresaRepository.ObtenerEmpresa(ofertadto.idempresas);
            oferta.empresas = empresa;
            if (this.OfertasRepository.existOfertas(oferta))
            {
                return this.OfertasRepository.actualizarOfertas(oferta);
            }
            else
            {
                return false;
            }
        }

        public List<OfertaDTO> obtenerOfertasempresa(int idempresa)
        {
            return mapper.Map<List<Ofertas>, List<OfertaDTO>>(this.OfertasRepository.obtenerOfertasempresa(idempresa));

        }

        public List<OfertaDTO> ObtenerOfertasCiclos(int id)
        {
            return mapper.Map<List<Ofertas>, List<OfertaDTO>>(this.OfertasRepository.ObtenerOfertasCiclos(id));

        }

        public List<OfertaDTO> getOfertasNoCaducadas(int id)
        {
            return mapper.Map<List<Ofertas>, List<OfertaDTO>>(this.OfertasRepository.getOfertasNoCaducadas(id));

        }
    }
}
