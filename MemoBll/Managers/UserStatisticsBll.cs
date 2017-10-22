using System;
using System.Collections.Generic;
using System.Linq;
using MemoBll.Interfaces;
using MemoBll.Logic;
using MemoDAL;
using MemoDAL.EF;
using MemoDTO;

namespace MemoBll.Managers
{
    public class UserStatisticsBll
    {
        IUserStatistics statistics;
        IConverterToDTO converterToDto;
        IConverterFromDTO converterFromDto;

        public UserStatisticsBll()
        {
            var uow = new UnitOfWork(new MemoContext());
            this.statistics = new UserStatistics(uow);
            this.converterToDto = new ConverterToDTO();
            this.converterFromDto = new ConverterFromDTO(uow);
        }

        public UserStatisticsBll(
            IUserStatistics statistics,
            IConverterToDTO converterToDto,
            IConverterFromDTO converterFromDto)
        {
            this.statistics = statistics;
            this.converterToDto = converterToDto;
            this.converterFromDto = converterFromDto;

        }

        public StatisticsDTO GetStatistics(
            string userId, int cardId)
        {
            var stats = statistics.GetStatistics(userId, cardId);
            return converterToDto.ConvertToStatisticsDTO(stats);
        }

        public IEnumerable<StatisticsDTO> GetDeckStatistics(
            string userLogin,
            int deckId)
        {
            var deckStatistics = statistics
                .GetDeckStatistics(userLogin, deckId);
            return deckStatistics
                ?.Select(s => converterToDto.ConvertToStatisticsDTO(s))
                ?? throw new ArgumentNullException();
        }

        public IEnumerable<StatisticsDTO> GetCourseStatistics(
            string userLogin,
            int courseId)
        {
            var courseStatistics = statistics
                .GetCourseStatistics(userLogin, courseId);
            return courseStatistics
                ?.Select(s => converterToDto.ConvertToStatisticsDTO(s))
                ?? throw new ArgumentNullException();
        }

        public StatisticsDTO CreateStatistics(StatisticsDTO statisticsDto)
        {
            var statisticsToCreate = converterFromDto
                .ConvertToStatistics(statisticsDto);
            var createdStatistics = statistics
                .CreateStatistics(statisticsToCreate);

            return converterToDto.ConvertToStatisticsDTO(createdStatistics);
        }

        public IEnumerable<StatisticsDTO> CreateDeckStatistics(
            string userLogin,
            int deckId)
        {
            var createdStatistics = statistics
                .CreateDeckStatistics(userLogin, deckId);

            return createdStatistics
                .Select(x => converterToDto.ConvertToStatisticsDTO(x));
        }

        public IEnumerable<StatisticsDTO> CreateCourseStatistics(
            string userLogin, 
            int courseId)
        {
           var createdStatistics = statistics
                .CreateCourseStatistics(userLogin, courseId);

            return createdStatistics
                .Select(x => converterToDto.ConvertToStatisticsDTO(x));
        }

        public StatisticsDTO UpdateStatistics(StatisticsDTO statisticsDto)
        {
            var statisticsToSave = converterFromDto
                .ConvertToStatistics(statisticsDto);
            var updatedStatistics = statistics.UpdateStatistics(statisticsToSave);

            return converterToDto.ConvertToStatisticsDTO(updatedStatistics);
        }

        public StatisticsDTO DeleteStatistics(int statisticsId)
        {
            var deletedStatistics = statistics.DeleteStatistics(statisticsId);
            return converterToDto.ConvertToStatisticsDTO(deletedStatistics);
        }
    }
}
