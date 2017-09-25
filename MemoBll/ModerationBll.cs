using System;
using System.Collections.Generic;
using System.Linq;
using MemoBll.Interfaces;
using MemoDAL;
using MemoDAL.Entities;
using MemoDAL.EF;
using MemoDTO;

namespace MemoBll
{
    public class ModerationBll
    {
        IModeration moderation;
        IConverterToDTO converterToDto;

        public ModerationBll()
        {
            moderation = new Moderation();
            converterToDto = new ConverterToDTO();
        }

        public ModerationBll(
            IModeration moderation, 
            IConverterToDTO converterToDto)
        {
            this.moderation = moderation;
            this.converterToDto = converterToDto;
        }

        public int GetReportCountForReason(string reason)
        {
            return moderation.GetReportCountForReason(reason);
        }

        public List<Report> GetAllReportsOnReason(string reason)
        {
            return moderation.GetAllReportsOnReason(reason).ToList();
        }

        public List<Report> GetAllReportsOnDate(DateTime date)
        {
            return moderation.GetAllReportsOnDate(date).ToList();
        }

        public List<Report> GetAllReportsFromDate(DateTime date)
        {
            return moderation.GetAllReportsFromDate(date).ToList();
        }

        public Report GetReport(int reportId)
        {
            return moderation.GetReport(reportId);
        }

        public int GetDeckStatistics(int deckId)
        {
            var deckStatistics = moderation.GetDeckStatistics(deckId).ToList();
            int result = 0;
            if (deckStatistics.Count > 0)
            {
                double totalDeckPercent = 0.0;
                foreach (Statistics statistic in deckStatistics)
                {
                    totalDeckPercent += statistic.SuccessPercent;
                }
                result = Convert.ToInt32(
                    Math.Round(totalDeckPercent / deckStatistics.Count));
            }

            return result;
        }

        public int GetStatistics(string deckName, int userId)
        {
            Statistics statistics = moderation.GetStatistics(deckName, userId);

            return statistics != null ? statistics.SuccessPercent : 0;
        }

        public void DeleteStatistics(Statistics statistics)
        {
            moderation.DeleteStatistics(statistics);
        }

        public List<UserDTO> GetAllUsersByCourse(int courseId)
        {
            List<User> users = moderation.GetAllUsersByCourse(courseId).ToList();
            List<UserDTO> usersDto = new List<UserDTO>();
            foreach (var user in users)
            {
                usersDto.Add(converterToDto.ConvertToUserDTO(user));
            }

            return usersDto;
        }

        public List<UserDTO> GetAllUsersByDeck(string deckName)
        {
            List<User> users = moderation.GetAllUsersByDeck(deckName).ToList();
            List<UserDTO> usersDto = new List<UserDTO>();
            foreach (var user in users)
            {
                usersDto.Add(converterToDto.ConvertToUserDTO(user));
            }

            return usersDto;
        }
    }
}
