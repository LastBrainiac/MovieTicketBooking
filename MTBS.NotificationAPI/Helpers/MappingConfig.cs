using AutoMapper;
using MTBS.NotificationAPI.EventBusIntegration.Messages;
using MTBS.NotificationAPI.Models;

namespace MTBS.NotificationAPI.Helpers
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<EmailLogMessage, EmailLog>()
                .ForMember(d => d.EmailSent, o => o.MapFrom(s => s.MessageCreated))
                .ForMember(d => d.LogText, o => o.MapFrom<LogTextValueResolver>())
                .ForMember(d => d.Id, o => o.Ignore());
        }
    }
}
