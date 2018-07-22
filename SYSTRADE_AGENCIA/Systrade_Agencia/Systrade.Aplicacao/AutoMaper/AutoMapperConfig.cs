using AutoMapper;

namespace Systrade.Aplicacao.AutoMaper
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(x => 
            {
                x.AddProfile<DomainToViewModelMappingProfile>();
            });            

        }
    }
}
