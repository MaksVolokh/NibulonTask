using AutoMapper;
using NibulonBLL.Dto;
using NibulonDAL.Entities;


namespace NibulonBLL.MappingProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<GrainElevatorArrivalsTable, GrainElevatorArrivalsTableDTO>();
            CreateMap<GrainElevatorArrivalsTableDTO, GrainElevatorArrivalsTable>();

            CreateMap<GrainElevatorArrivalsTable, GroupedDataTableDTO>();
            CreateMap<GroupedDataTableDTO, GrainElevatorArrivalsTable>();
                
            CreateMap<GrainElevatorArrivalsTable, WeightedAverageTableDTO>()
                .ForMember(dest => dest.AverageMoisture, opt => opt.MapFrom(src => CalculateAverageMoisture(src)))
                .ForMember(dest => dest.AverageImpurity, opt => opt.MapFrom(src => CalculateAverageImpurity(src)))
                .ForMember(dest => dest.AverageContamination, opt => opt.MapFrom(src => CalculateAverageContamination(src)));
            
        }

        private decimal? CalculateAverageMoisture(GrainElevatorArrivalsTable source)
        {
            decimal? totalMoisture = 0;
            int count = 0;

            foreach (var record in source)
            {
                totalMoisture += record.Moisture;
                count++;
            }

            decimal? averageMoisture = count > 0 ? totalMoisture / count : 0;

            return averageMoisture;
        }

        private decimal? CalculateAverageImpurity(GrainElevatorArrivalsTable source)
        {
            decimal? totalImpurity = 0;
            int count = 0;

            foreach (var record in source)
            {
                totalImpurity += record.Impurity;
                count++;
            }

            decimal? averageImpurity = count > 0 ? totalImpurity / count : 0;

            return averageImpurity;
        }

        private string CalculateAverageContamination(GrainElevatorArrivalsTable source)
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
