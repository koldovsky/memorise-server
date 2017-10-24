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
        IConverterToDTO converterToDTO;
        IConverterFromDTO converterFromDTO;

        public UserStatisticsBll()
        {
            var uow = new UnitOfWork(new MemoContext());
            statistics = new UserStatistics(uow);
            converterToDTO = new ConverterToDTO();
            converterFromDTO = new ConverterFromDTO(uow);
        }

        public UserStatisticsBll(
            IUserStatistics statistics,
            IConverterToDTO converterToDTO,
            IConverterFromDTO converterFromDTO)
        {
            this.statistics = statistics;
            this.converterToDTO = converterToDTO;
            this.converterFromDTO = converterFromDTO;

        }

        public StatisticsDTO GetStatistics(
            string userId, int cardId)
        {
            var stats = statistics.GetStatistics(userId, cardId);
            return stats != null
                ? converterToDTO.ConvertToStatisticsDTO(stats)
                : null;
        }

        public IEnumerable<StatisticsDTO> GetDeckStatistics(
            string userLogin,
            int deckId)
        {
            var deckStatistics = statistics
                .GetDeckStatistics(userLogin, deckId);
            return deckStatistics
                ?.Select(s => s != null
                    ? converterToDTO.ConvertToStatisticsDTO(s)
                    : null)
                ?? throw new ArgumentNullException();
        }

        public IEnumerable<StatisticsDTO> GetCourseStatistics(
            string userLogin,
            int courseId)
        {
            var courseStatistics = statistics
                .GetCourseStatistics(userLogin, courseId);
            return courseStatistics
                ?.Select(s => s != null
                           ? converterToDTO.ConvertToStatisticsDTO(s)
                           : null)
                ?? throw new ArgumentNullException();
        }

        public StatisticsDTO CreateStatistics(string userLogin, int cardId)
        {
            var createdStatistics = statistics
                .CreateStatistics(userLogin, cardId);

            return converterToDTO.ConvertToStatisticsDTO(createdStatistics);
        }

        public IEnumerable<StatisticsDTO> CreateDeckStatistics(
            string userLogin,
            int deckId)
        {
            var createdStatistics = statistics
                .CreateDeckStatistics(userLogin, deckId);

            return createdStatistics
                .Select(x => converterToDTO.ConvertToStatisticsDTO(x));
        }

        public IEnumerable<StatisticsDTO> CreateCourseStatistics(
            string userLogin,
            int courseId)
        {
            var createdStatistics = statistics
                 .CreateCourseStatistics(userLogin, courseId);

            return createdStatistics
                .Select(x => converterToDTO.ConvertToStatisticsDTO(x));
        }

        public StatisticsDTO UpdateStatistics(StatisticsDTO statisticsDTO)
        {
            var statisticsToSave = converterFromDTO
                .ConvertToStatistics(statisticsDTO);
            var updatedStatistics = statistics.UpdateStatistics(statisticsToSave);

            return converterToDTO.ConvertToStatisticsDTO(updatedStatistics);
        }

        public StatisticsDTO DeleteStatistics(int statisticsId)
        {
            var deletedStatistics = statistics.DeleteStatistics(statisticsId);
            return converterToDTO.ConvertToStatisticsDTO(deletedStatistics);
        }
    }
}
