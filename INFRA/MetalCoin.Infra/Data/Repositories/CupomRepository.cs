using Metalcoin.Core.Domain;
using Metalcoin.Core.Enums;
using Metalcoin.Core.Interfaces.Repositories;
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

        Task<Cupom> ICupomRepository.BuscarPorAtivos(StatusCupom statusCupom)
        {
             
            throw new NotImplementedException();
        }

        Task<Cupom> ICupomRepository.BuscarPorInativos(StatusCupom statusCupom)
        {
            throw new NotImplementedException();
        }
    }
}
