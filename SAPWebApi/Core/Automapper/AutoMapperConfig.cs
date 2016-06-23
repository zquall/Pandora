using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BusinessOneObjects.Request;
using DataObjects.Customer;
using DataObjects.Item;
using Extensions.Automapper;
using Extensions.Types;

namespace Core.Automapper
{
    public static class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(x => x.AddProfile<SapMapping>());

            Mapper.AssertConfigurationIsValid();
        }
    }

    public class SapMapping : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<CustomerInvoice, Bombo>()
                .IgnoreAllUnmapped()
                .ForMember(dest => dest.Document_Lines, opts => opts.MapFrom(src => src.ItemDetails))
                .ForMember(dest => dest.Documents, opts => opts.MapFrom(src => new[] { Mapper.Map<BOMBORow>(src) }));

            Mapper.CreateMap<CustomerInvoice, BOMBORow>()
                .IgnoreAllUnmapped()
                .ForMember(dest => dest.DocNum, opts => opts.MapFrom(src => src.DocumentId))
                .ForMember(dest => dest.CardCode, opts => opts.MapFrom(src => src.CustomerCode))
                .ForMember(dest => dest.DocDate, opts => opts.MapFrom(src => src.PostingDate.ToYearMonthDay()))
                .ForMember(dest => dest.DocDueDate, opts => opts.MapFrom(src => src.DueDate.ToYearMonthDay()))
                .ForMember(dest => dest.TaxDate, opts => opts.MapFrom(src => src.DocumentDate.ToYearMonthDay()))
                .ForMember(dest => dest.SalesPersonCode, opts => opts.MapFrom(src => src.SellerCode))
                .ForMember(dest => dest.HandWritten, opts => opts.ResolveUsing<AutomapperResolver.SapBooleanResolver>().FromMember(src => src.HandWritten))
                .ForMember(dest => dest.ManualNumber, opts => opts.ResolveUsing<AutomapperResolver.SapBooleanResolver>().FromMember(src => src.ManualNumber))

                .ForMember(dest => dest.Comments, opts => opts.MapFrom(src => src.Comments))

                 .ForMember(dest => dest.U_SCG_TipoDocumento, opts => opts.MapFrom(src => src.DocumentType));
            


            

            Mapper.CreateMap<ItemDetail, BOMBORowLines>()
             .ForMember(dest => dest.TaxLiable, opts => opts.ResolveUsing<AutomapperResolver.SapBooleanResolver>().FromMember(src => src.TaxLiable));

            
            Mapper.CreateMap<CustomerProject, AddProject>()
                  .IgnoreAllUnmapped()
                  .ForMember(dest => dest.Project, opts => opts.MapFrom(src => src));

            Mapper.CreateMap<CustomerProject, UpdateProject>()
                .IgnoreAllUnmapped()
                .ForMember(dest => dest.Project, opts => opts.MapFrom(src => src));

            Mapper.CreateMap<CustomerProject, Project>();
            

        }
    }
}
