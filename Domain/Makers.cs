// <copyright file="Product.cs" company="Агамалян-Муртазина">
// Copyright (c) Агамалян-Муртазина. All rights reserved.
// </copyright>

namespace Domain
{
    using System;
    using System.Collections.Generic;
    using Staff.Extensions;

    /// <summary>
    /// Производитель.
    /// </summary>
    public class Maker
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Maker"/>.
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="title">Название.</param>
        /// <param name="foundationDate">Дата основания.</param>
        public Author(int id, string title, DateTime foundationDate)
        {
            this.Id = id;
            this.Title = title.TrimOrNull() ?? throw new ArgumentOutOfRangeException(nameof(title));
            this.FoundationDate = foundationDate;
        }

        /// <summary>
        /// Уникальный идентификатор.
        /// </summary>
        public int Id { get; protected set; }

        /// <summary>
        /// Название производителя.
        /// </summary>
        public string Title { get; protected set; }

        /// <summary>
        /// Получает или задает дату основания производтля.
        /// </summary>
        public DateTime FoundationDate { get; set; }

        /// <summary>
        /// Список продуктов производителя.
        /// </summary>
        public ISet<Product> Products{ get; protected set; } = new HashSet<Product>();

        /// <summary>
        /// Добавить продукт производителю.
        /// </summary>
        /// <param name="product"> Добавляемый продукт. </param>
        /// <returns>
        /// <see langword="true"/> если продукт был добавлен.
        /// </returns>
        public bool AddProduct(Product product)
        {
            var answer = this.Products.TryAdd(product) ?? throw new ArgumentNullException(nameof(product));
            return answer;
        }
    }
}