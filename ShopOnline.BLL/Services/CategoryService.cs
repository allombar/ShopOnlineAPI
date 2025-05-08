using ShopOnline.BLL.interfaces;
using ShopOnline.BLL.Mappers;
using ShopOnline.BLL.Models;
using ShopOnline.DAL.Entities;
using ShopOnline.DAL.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.BLL.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;

        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<CategoryEntity> GetAll()
        {
            var categories = _repository.GetAll();

            if (categories == null)
                throw new InvalidOperationException("Erreur interne : aucune donnée récupérée.");

            if (!categories.Any())
                throw new InvalidOperationException("Aucune catégorie trouvée.");

            return categories;
        }

        public Category GetById(int id)
        {
            Category? category = _repository.GetById(id).ToBll();

            if (category is null)
                throw new ArgumentException("La catégorie est introuvable");

            if (id <= 0)
                throw new ArgumentException("L'identifiant doit être supérieur à zéro.");

            return category;
        }

        public void Create(Category dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            if (string.IsNullOrWhiteSpace(dto.Name))
                throw new ArgumentException("Le nom de la catégorie est obligatoire.");

            // Règle métier : pas de doublon de nom
            foreach (var existing in _repository.GetAll())
            {
                if (string.Equals(existing.Name.Trim(), dto.Name.Trim(), StringComparison.OrdinalIgnoreCase))
                    throw new InvalidOperationException("Une catégorie avec ce nom existe déjà.");
            }

            var category = dto.ToEntity();
            _repository.Add(category);
        }

        public void Update(int id, Category category)
        {
            _repository.Update(id, category.ToEntity());
        }

        public void Delete(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Identifiant invalide.");

            var existing = _repository.GetById(id);
            if (existing == null)
                throw new InvalidOperationException("La catégorie à supprimer n'existe pas.");

            _repository.Delete(existing);
        }
    }
}