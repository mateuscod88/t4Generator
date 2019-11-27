
using ICE.Infrastructure.Commands;

namespace EZDRP.Sprawy.AS.QueriesDto
{
    [SwaggerSummary(QuerySwaggerDescriptions.PobierzHistorieNotatki_Summary)]
    [SwaggerDescription(QuerySwaggerDescriptions.PobierzHistorieNotatki_Description)]
    [HttpCommand(HttpQueryNames.PobierzHistorieNotatkiQuery)]
    [SwaggerTags(TagiSwagger.QueryTag)]
    public class PobierzHistorieNotatkiQuery : QueryDtoBase
    {
        [SwaggerDescription(QuerySwaggerDescriptions.PobierzHistorieNotatki_Summary)]
        public string Id { get; set; }

        
    }
}
