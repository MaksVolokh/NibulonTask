using AutoMapper;
using NibulonBLL.Dto;
using NibulonDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NibulonBLL.MappingProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Table1, Table1DTO>();
            CreateMap<Table1DTO, Table1>();

            CreateMap<Table1, Table2DTO>();
            CreateMap<Table2DTO, Table1>();
                
            CreateMap<Table1, Table3DTO>()
                .ForMember(dest => dest.AverageMoisture, opt => opt.MapFrom(src => CalculateAverageMoisture(src)))
                .ForMember(dest => dest.AverageImpurity, opt => opt.MapFrom(src => CalculateAverageImpurity(src)))
                .ForMember(dest => dest.AverageContamination, opt => opt.MapFrom(src => CalculateAverageContamination(src)));
            
        }

        private decimal CalculateAverageMoisture(Table1 source)
        {
            decimal totalMoisture = 0;
            int count = 0;

            foreach (var record in source)
            {
                totalMoisture += record.Moisture;
                count++;
            }

            decimal averageMoisture = count > 0 ? totalMoisture / count : 0;

            return averageMoisture;
        }

        private decimal CalculateAverageImpurity(Table1 source)
        {
            decimal totalImpurity = 0;
            int count = 0;

            foreach (var record in source)
            {
                totalImpurity += record.Impurity;
                count++;
            }

            decimal averageImpurity = count > 0 ? totalImpurity / count : 0;

            return averageImpurity;
        }

        private string CalculateAverageContamination(Table1 source)
        {
            Dictionary<string, int> contaminationCounts = new Dictionary<string, int>();

            foreach (var row in source)
            {
                string contaminationValue = row.Contamination;

                if (contaminationCounts.ContainsKey(contaminationValue))
                {
                    contaminationCounts[contaminationValue]++;
                }

                else
                {
                    contaminationCounts[contaminationValue] = 1;
                }
            }

            int maxCount = contaminationCounts.Values.Max();

            List<string> mostRepeatedValues = contaminationCounts
                .Where(pair => pair.Value == maxCount)
                .Select(pair => pair.Key)
                .ToList();

            return mostRepeatedValues.FirstOrDefault();
        }

        public static IMapper Configure()
        {

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });

            IMapper mapper = config.CreateMapper();
            return mapper;

        }

    }
}
