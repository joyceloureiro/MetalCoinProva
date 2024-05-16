﻿using Metalcoin.Core.Domain;
using Metalcoin.Core.Enums;
using Metalcoin.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetalCoin.Infra.Data.Repositories
{
    public class CupomRepository : Repository<Cupom>, ICupomRepository
    {
        public CupomRepository(AppDbContext appDbContext) : base(appDbContext) { }

        public async Task<Cupom> BuscarPorAtivos(StatusCupom statusCupom)
        {

            var resultado = await DbSet.Where(c => c.StatusCupom == statusCupom).FirstOrDefaultAsync();
            return resultado;
        }

        public async Task<Cupom> BuscarPorInativos(StatusCupom statusCupom)
        {
            var resultado = await DbSet.Where(c => c.StatusCupom == statusCupom).FirstOrDefaultAsync();
            return resultado;
        }

        public async Task<Cupom> DesativarCupom(StatusCupom statusCupom)
        {
            var resultado = await DbSet.Where(c => c.StatusCupom == statusCupom).FirstOrDefaultAsync();
            return resultado;
        }
    }
}
