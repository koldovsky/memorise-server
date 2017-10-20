using MemoBll.Interfaces;
using MemoBll.Logic;
using MemoDTO;
using System.Collections.Generic;
using System.Linq;

namespace MemoBll.Managers
{
	public class CatalogBll
    {
        ICatalog catalog;
        IConverterToDto converterToDto;

        public CatalogBll()
        {
			this.catalog = new Catalog();
            this.converterToDto = new ConverterToDto();
        }

        public CatalogBll(ICatalog catalog, IConverterToDto converter)
        {
			this.catalog = catalog;
            this.converterToDto = converter;
        }

        public IEnumerable<CategoryDTO> GetAllCategories()
        {
			return catalog.GetAllCategories()
				.Select(c => converterToDto.ConvertToCategoryDto(c));
        }

        public IEnumerable<CourseDTO> GetAllCourses()
        {
            return catalog.GetAllCourses()
				.Select(c => converterToDto.ConvertToCourseDto(c));

        }

        public IEnumerable<DeckDTO> GetAllDecks()
        {
            return catalog.GetAllDecks()
				.Select(d => converterToDto.ConvertToDeckDto(d));
        }

        public IEnumerable<DeckDTO> GetAllDecksByCourse(string courseName)
        {
            return catalog.GetAllDecksByCourse(courseName)
				.Select(d => converterToDto.ConvertToDeckDto(d));
        }

        public IEnumerable<DeckDTO> GetAllDecksByCategory(string categoryName)
        {
			return catalog.GetAllDecksByCategory(categoryName)
				.Select(d => converterToDto.ConvertToDeckDto(d));
        }

        public IEnumerable<CourseDTO> GetAllCoursesByCategory(string categoryLinking)
        {
            return catalog.GetAllCoursesByCategory(categoryLinking)
				.Select(c => converterToDto.ConvertToCourseDto(c));
        }

        public CourseWithDecksDTO GetCourseWithDecksDTO(string courseName)
        {
			return converterToDto.ConvertToCourseWithDecksDto(
				catalog.GetCourse(courseName));
        }

        public DeckDTO GetDeckDTO(string linking)
        {
            return converterToDto.ConvertToDeckDto(catalog.GetDeck(linking));
        }
    }
}
