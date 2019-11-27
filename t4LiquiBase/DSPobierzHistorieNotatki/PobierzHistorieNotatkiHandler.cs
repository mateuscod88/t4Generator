
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EZDRP.Common.Context;
using EZDRP.Sprawy.AS.CommandsRole.Generators;
using EZDRP.Sprawy.Common;
using EZDRP.Sprawy.DS.CommandsDto;
using EZDRP.Sprawy.DS.Data.Entities;
using EZDRP.Sprawy.DS.Data.Repositories;
using EZDRP.Sprawy.SharedDto;
using ICE.Data.Core;
using ICE.Infrastructure;
using ICE.Infrastructure.Commands;

namespace  EZDRP.Sprawy.DS.QueriesRole.Queries
{
    public class PobierzHistorieNotatkiHandler : QueryHandler<PobierzHistorieNotatkiQuery>
    {
        private readonly IRepositoryProvider<ISprawaCommandRepository> _sprawaRepositoryProvider;
        private readonly IClock _clock;
        private readonly IDbTransactionFactory _dbTransactionFactory;
        private readonly IDSMapper _mapper;
        private readonly IEZDRPContext _ezdrpContext;
        private readonly ISprawaIdGenerator _sprawaIdGenerator;

        public PobierzHistorieNotatkiHandler(
            IDbTransactionFactory dbTransactionFactory,
            IDSMapper mapper,
            IClock clock,
            IEZDRPContext ezdrpContext,
            IRepositoryProvider<ISprawaCommandRepository> sprawaRepositoryProvider,
            ISprawaIdGenerator sprawaIdGenerator)
        {
            _clock = clock ?? throw new ArgumentNullException(nameof(clock));
            _ezdrpContext = ezdrpContext ?? throw new ArgumentNullException(nameof(ezdrpContext));
            _sprawaRepositoryProvider = sprawaRepositoryProvider;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _dbTransactionFactory = dbTransactionFactory ?? throw new ArgumentNullException(nameof(dbTransactionFactory));
            _sprawaIdGenerator = sprawaIdGenerator ?? throw new ArgumentNullException(nameof(sprawaIdGenerator));
        }

        public async override Task<object> InvokeAsync(PobierzHistorieNotatkiQuery input, Dictionary<string, string> properties)
        {
            var repository = await _sprawaRepositoryProvider.Get();

            await _dbTransactionFactory.Create().BeforeCommit(async () =>
            {
                    var entity = _mapper.Map<Sprawa>(input);
                    entity.DataUtworzenia = _clock.Now;
                    entity.DataRejestracji = _clock.Now;
                    entity.IdUzytkownikProwadzacy = _ezdrpContext.UzytkownikId;
                    entity.IdUzytkownikInicjujacy = _ezdrpContext.UzytkownikId;
                    entity.IdPodmiotWlascicielBiznesowy = _ezdrpContext.PodmiotId;
                    entity.Status = StatusSprawy.W_Toku;
                    entity.Numer = input.Numer;
                    entity.ListaWplyw = new List<SprawaWplyw>
                    {
                        new SprawaWplyw
                        {
                            Id = _sprawaIdGenerator.Generate(),
                            IdSprawa = input.Id,
                            CzyGlowny = true,
                            IdRPWWplyw = input.IdRPWWplyw,
                            DataUtworzenia = _clock.Now,
                            IdPodmiotWlascicielBiznesowy = _ezdrpContext.PodmiotId,
                            IdUzytkownikInicjujacy = _ezdrpContext.UzytkownikId
                        }
                    };
                    await repository.Add(entity);
            }).Commit();

            return null;
        }

        public override Task<object> CommitAsync(PobierzHistorieNotatkiQuery input, Dictionary<string, string> properties)
        {
            throw new NotImplementedException();
        }

        public override Task<object> RollbackAsync(PobierzHistorieNotatkiQuery input, Dictionary<string, string> properties)
        {
            throw new NotImplementedException();
        }
    }
}
