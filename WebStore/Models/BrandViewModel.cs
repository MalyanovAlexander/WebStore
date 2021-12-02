using WebStore.DomainNew.Entities.Base.Interfaces;

namespace WebStore.Models
{
    public class BrandViewModel : INamedEntity, IOrderedEntity
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public int Order { get; set; }

        /// <summary>
        ///Количество товаров бренда 
        /// </summary>
        public int ProductsCount { get; set; }
    }
}
