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
            string userName,
            int deckId)
        {
            var deckStatistics = statistics
                .GetDeckStatistics(userName, deckId);
            return deckStatistics
                ?.Select(s => converterToDto.ConvertToStatisticsDTO(s))
                ?? throw new ArgumentNullException();
        }

        public IEnumerable<StatisticsDTO> GetCourseStatistics(
            string userName,
            int courseId)
        {
            var courseStatistics = statistics
                .GetCourseStatistics(userName, courseId);
            return courseStatistics
                ?.Select(s => converterToDto.ConvertToStatisticsDTO(s))
                ?? throw new ArgumentNullException();
        }

        public void CreateStatistics(StatisticsDTO statisticsDto)
        {
            var statisticsToCreate = converterFromDto
                .ConvertToStatistics(statisticsDto);
            statistics.CreateStatistics(statisticsToCreate);
        }

        public void CreateDeckStatistics(string userName, int deckId)
        {
            statistics.CreateDeckStatistics(userName, deckId);
        }

        public void CreateCourseStatistics(string userName, int courseId)
        {
            statistics.CreateCourseStatistics(userName, courseId);
        }

        public void UpdateStatistics(StatisticsDTO statisticsDto)
        {
            var statisticsToSave = converterFromDto
                .ConvertToStatistics(statisticsDto);
            statistics.UpdateStatistics(statisticsToSave);
        }

        public void DeleteStatistics(int statisticsId)
        {
            statistics.DeleteStatistics(statisticsId);
        }
    }
}
