using AutoMapper;

namespace Systyrade.Eventos.Aplicacao.AutoMapper
{
    public class AutoMapperEventsConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<EventsDomainToViewModelMappingProfile>();
            });

        }
    }
}
