using System;
using System.Collections.Generic;
using System.Linq;
using MemoDAL;
using MemoDAL.Entities;
using MemoDAL.EF;
using MemoDTO;

namespace MemoBll
{
    class Moderation
    {
        IUnitOfWork unitOfWork;
        IConverterToDTO converterToDto;

        public Moderation()
        {
            this.unitOfWork = new UnitOfWork(new MemoContext());
            this.converterToDto = new ConverterToDto();
        }

        public Moderation(IUnitOfWork unitOfWork, IConverterToDTO converterToDto)
        {
            this.unitOfWork = unitOfWork;
            this.converterToDto = converterToDto;
        }

        public int GetReportCountForReason(string reason)
        {
            return unitOfWork.Reports
                .GetAll().Where(x => x.Reason == reason).Count();
        }

        public List<Report> GetAllReportsOnReason(string reason)
        {
            return unitOfWork.Reports
                .GetAll().Where(x => x.Reason == reason).ToList();
        }

        public List<Report> GetAllReportsOnDate(DateTime date)
        {
            return unitOfWork.Reports
                .GetAll().Where(x => x.Date == date).ToList();
        }

        public List<Report> GetAllReportsFromDate(DateTime date)
        {
            return unitOfWork.Reports
                .GetAll().Where(x => x.Date >= date).ToList();
        }

        public Report GetReport(int reportId)
        {
            return unitOfWork.Reports.Get(reportId);
        }

        public int GetDeckStatistics(int deckId)
        {
            int result = 0;
            List<Statistics> deckStatistics = unitOfWork.Statistics
                .GetAll().Where(x => x.Deck.Id == deckId).ToList();

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
            List<Statistics> statistics = unitOfWork.Statistics
                .GetAll().Where(x =>
                x.Deck.Name == deckName && x.User.Id == userId).ToList();

            return statistics.Count > 1 ? statistics[0].SuccessPercent : 0;
        }

        public void DeleteStatistics(Statistics statistics)
        {
            unitOfWork.Statistics.Delete(statistics);
            unitOfWork.Save();
        }

        public List<UserDTO> GetAllUsersByCourse(int courseId)
        {
            List<UserCourse> userCourses = unitOfWork.UserCourses
                .GetAll().Where(x => x.Course.Id == courseId).ToList();
            List<UserDTO> users = new List<UserDTO>();
            foreach (UserCourse userCourse in userCourses)
            {
                users.Add(converterToDto.ConvertToUserDTO(userCourse.User));
            }

            return users;
        }

        public List<UserDTO> GetAllUsersByDeck(string deckName)
        {
            List<Statistics> statistics = unitOfWork.Statistics
                .GetAll().Where(x => x.Deck.Name == deckName).ToList();
            List<UserDTO> users = new List<UserDTO>();
            foreach (Statistics item in statistics)
            {
                users.Add(converterToDto.ConvertToUserDTO(item.User));
            }

            return users;
        }
    }
}
