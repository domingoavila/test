using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapperSample
{
    public class CustomMap: Profile
    {

      public override string ProfileName { get { return "CustomMap"; } }
      protected override void Configure()
        {
            Mapper.CreateMap<CustomerModel, Customer>()
                  //.ForMember(d => d.Name, o => o.MapFrom(c => c.Name))
                  .ForMember(d => d.LastName, o => o.MapFrom(c => c.fLastName));
                  //.ForMember(d => d.Email, o => o.MapFrom(c => c.Email));
        }
    }
}
