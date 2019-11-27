
using System;
using ICE.Infrastructure.Commands;

namespace EZDRP.Sprawy.DS.QueriesDto
{
    [HttpCommand(HttpQueryNames.PobierzHistorieNotatkiQuery)]
    public class PobierzHistorieNotatkiQuery : QueryDtoBase
    {
        public string Id { get; set; }
    }
}
