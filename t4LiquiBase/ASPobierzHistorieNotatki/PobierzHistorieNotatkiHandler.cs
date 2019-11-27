
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using COMMON.StrukturaOrganizacyjna.ResultsDto;
using EZDRP.JRWA.ResultsDto;
using EZDRP.KorespondencjaPrzychodzaca.Common;
using EZDRP.Sprawy.AS.CommandsDto;
using EZDRP.Sprawy.AS.CommandsRole.Generators;
using EZDRP.Sprawy.ResultsDto;
using ICE.Infrastructure.Commands;

namespace EZDRP.Sprawy.AS.QueriesRole.Queries
{
    public class PobierzHistorieNotatkiHandler : QueryHandler<PobierzHistorieNotatkiQuery>
    {
        private readonly ICommandGateway _commandGateway;
        private readonly ISprawaIdGenerator _sprawaIdGenerator;
        private readonly ICommandContext _commandContext;

        public PobierzHistorieNotatkiHandler(
            ICommandGateway commandGateway,
            ISprawaIdGenerator sprawaIdGenerator,
            ICommandContext commandContext)
        {
            _commandGateway = commandGateway ?? throw new ArgumentNullException(nameof(commandGateway));
            _sprawaIdGenerator = sprawaIdGenerator ?? throw new ArgumentNullException(nameof(sprawaIdGenerator));
            _commandContext = commandContext ?? throw new ArgumentNullException(nameof(commandContext));
        }

        public override Task<object> CommitAsync(PobierzHistorieNotatkiQuery input, Dictionary<string, string> properties)
        {
            throw new NotImplementedException();
        }

        public override Task<object> RollbackAsync(PobierzHistorieNotatkiQuery input, Dictionary<string, string> properties)
        {
            throw new NotImplementedException();
        }

        public override async Task<object> InvokeAsync(PobierzHistorieNotatkiQuery input, Dictionary<string, string> properties)
        {
        
            var utworzSpraweCommand = new DS.QuerysDto.PobierzHistorieNotatkiQuery()
            {
                Id = _sprawaIdGenerator.Generate(),
                IdPrzestrzenRobocza = idPrzestrzenRoboczaInicjujaca,
                IdRPWWplyw = input.IdRPWWplyw,
                IdJRWASchematWykaz = input.IdJRWASchematWykaz,
                Numer = nadajNumerSprawy,
                KategoriaArchiwalna = input.KategoriaArchiwalna,
                TypProwadzenia = schematwykazJRWA.TypProwadzenia,
                Tytul = wplyw.Tytul,
                TerminZalatwienia = UtworzTerminZalatwieniaSprawy(wplyw.DataWplywu, schematwykazJRWA.LiczbaDni),
                Znak = await BudujZnakSprawy(nadajNumerSprawy, input.RokZalozenia, schematwykazJRWA.Symbol, jednostkaSymbol),
                RokZalozenia = input.RokZalozenia,
                IdJednostka = uzytkownik.IdJednostka,
            };

            return new string();
        }
    }
}
