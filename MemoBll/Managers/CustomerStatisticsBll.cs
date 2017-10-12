using System.Collections.Generic;
using MemoBll.Interfaces;
using MemoBll.Logic;
using MemoDAL;
using MemoDAL.EF;
using MemoDTO;

namespace MemoBll.Managers
{
    public class CustomerStatisticsBll
    {
        ICustomerStatistics statistics;
        IConverterToDTO converterToDto;
        IConverterFromDTO converterFromDto;

        public CustomerStatisticsBll()
        {
            this.statistics = new CustomerStatistics(
                new UnitOfWork(new MemoContext()));
            this.converterToDto = new ConverterToDTO();
            this.converterFromDto = new ConverterFromDTO();
        }

        public CustomerStatisticsBll(
            ICustomerStatistics statistics,
            IConverterToDTO converterToDto,
            IConverterFromDTO converterFromDto)
        {
            this.statistics = statistics;
            this.converterToDto = converterToDto;
            this.converterFromDto = converterFromDto;

        }

        public IEnumerable<StatisticsDTO> GetStatistics(
            string userId, int cardId)
        {
            var statisticsList = statistics.GetStatistics(userId, cardId);
            return converterToDto.ConvertToStatisticsListDTO(statisticsList);
        }

        public void SaveStatistics(StatisticsDTO statisticsDto)
        {
            var statisticsToSave = converterFromDto.ConvertToStatistics(statisticsDto);
            statistics.SaveStatistics(statisticsToSave);
        }
    }
}
