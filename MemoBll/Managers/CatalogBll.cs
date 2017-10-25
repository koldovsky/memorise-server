using MemoBll.Interfaces;
using MemoBll.Logic;
using MemoDTO;
using System.Collections.Generic;
using System.Linq;

namespace MemoBll.Managers
{
	public class CatalogBll
    {
        private ICatalog catalog;
        private IConverterToDTO converterToDTO;

        public CatalogBll()
        {
			this.catalog = new Catalog();
            this.converterToDTO = new ConverterToDTO();
        }

        public CatalogBll(ICatalog catalog, IConverterToDTO converter)
        {
			this.catalog = catalog;
            this.converterToDTO = converter;
        }

        public IEnumerable<CategoryDTO> GetAllCategories()
        {
			return catalog.GetAllCategories()
				.Select(c => converterToDTO.ConvertToCategoryDTO(c));
        }

        public IEnumerable<CourseDTO> GetAllCourses()
        {
            return catalog.GetAllCourses()
				.Select(c => converterToDTO.ConvertToCourseDTO(c));
        }

        public IEnumerable<DeckDTO> GetAllDecks()
        {
            return catalog.GetAllDecks()
				.Select(d => converterToDTO.ConvertToDeckDTO(d));
        }

        public IEnumerable<DeckDTO> GetAllDecksByCourse(string courseName)
        {
            return catalog.GetAllDecksByCourse(courseName)
				.Select(d => converterToDTO.ConvertToDeckDTO(d));
        }

        public IEnumerable<DeckDTO> GetAllDecksByCategory(string categoryName)
        {
			return catalog.GetAllDecksByCategory(categoryName)
				.Select(d => converterToDTO.ConvertToDeckDTO(d));
        }

        public IEnumerable<CourseDTO> GetAllCoursesByCategory(string categoryLinking)
        {
            return catalog.GetAllCoursesByCategory(categoryLinking)
				.Select(c => converterToDTO.ConvertToCourseDTO(c));
        }

        public CourseWithDecksDTO GetCourseWithDecksDTO(string courseName)
        {
			return converterToDTO.ConvertToCourseWithDecksDTO(
				catalog.GetCourse(courseName));
        }

        public DeckDTO GetDeckDTO(string linking)
        {
            return converterToDTO.ConvertToDeckDTO(catalog.GetDeck(linking));
        }
    }
}
