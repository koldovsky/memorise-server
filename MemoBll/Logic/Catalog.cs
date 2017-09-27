using MemoBll.Interfaces;
using MemoDAL;
using MemoDAL.EF;
using MemoDAL.Entities;
using System.Collections.Generic;
using System.Linq;

namespace MemoBll.Logic
{
	public class Catalog : ICatalog
	{
		IUnitOfWork unitOfWork;

		public Catalog()
		{
			unitOfWork = new UnitOfWork(new MemoContext());
		}

		public Catalog(IUnitOfWork uow)
		{
			unitOfWork = uow;
		}

		public IEnumerable<Category> GetAllCategories()
		{
			return unitOfWork.Categories.GetAll();
		}

		public IEnumerable<Course> GetAllCourses()
		{
			return unitOfWork.Courses.GetAll();
		}

		public IEnumerable<Deck> GetAllDecks()
		{
			return unitOfWork.Decks.GetAll();
		}

		public IEnumerable<Deck> GetAllDecksByCourse(string courseLinking)
		{
			return unitOfWork.Courses
				.GetAll()
				.First(x => x.Linking == courseLinking)
				.Decks;
		}

		public IEnumerable<Deck> GetAllDecksByCategory(string categoryName)
		{
			return unitOfWork.Categories
				.GetAll()
				.First(x => x.Name == categoryName)
				.Decks;
		}

		public IEnumerable<Course> GetAllCoursesByCategory(string categoryName)
		{
			return unitOfWork.Categories
			.GetAll()
			.First(x => x.Name == categoryName)
			.Courses;
		}

		public Course GetCourse(string courseLinking)
		{
			return unitOfWork.Courses
				.GetAll()
				.First(x => x.Linking == courseLinking);
		}
	}
}
