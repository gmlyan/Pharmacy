// <copyright file="Product.cs" company="Агамалян-Муртазина">
// Copyright (c) Агамалян-Муртазина. All rights reserved.
// </copyright>

namespace Domain
{
    using System;
    using System.Collections.Generic;
    using Staff.Extensions;

    /// <summary>
    /// Товар.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Product"/>.
        /// </summary>
        /// <param name="id">Уникальный идентификатор.</param>
        /// <param name="title">Название.</param>
        /// <param name="price">Цена</param>
        /// <param name="quanity">Количество.</param>
        /// <param name="makers">Список производителей.</param>
        public Product(int id, string title, int price, int quanity, params Maker[] makers)
            : this(id, title, new HashSet<Maker>(makers)) 
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Product"/>.
        /// </summary>
        /// <param name="id">Уникальный идентификатор.</param>
        /// <param name="title">Название.</param>
        /// <param name="price">Цена</param>
        /// <param name="quanity">Количество.</param>
        /// <param name="makers">Список производителей.</param>
        public Product(int id, string title, int price, int quanity, ISet<Maker> makers = null)
        {
            this.Id = id;
            this.Title = title.TrimOrNull() ?? throw new ArgumentOutOfRangeException(nameof(title));
            this.Price = price;
            this.Quanity = quanity;
            if (makers != null)
            {
                foreach (var maker in makers)
                {
                    this.Makers.Add(maker);
                    maker.AddMaker(this);
                }
            }
        }
        

        /// <summary>
        /// Получает или задает уникальный идентификатор.
        /// </summary>
        public int Id { get; protected set; }

        /// <summary>
        /// Получает или задает название товара.
        /// </summary>
        public string Title { get; protected set; }

        /// <summary>
        /// Получает или задает цену продукта.
        /// </summary>
        public int Price { get; protected set; }

        /// <summary>
        /// Получает или задает кол-во продукта.
        /// </summary>
        public int quanity { get; protected set; }

        /// <summary>
        /// Список производителей.
        /// </summary>
        public ISet<Maker> Makers{ get; protected set; } = new HashSet<Maker>();

        /// <inheritdoc/>
        public override string ToString() => $"{this.Title} {this.Makers.Join()}";
    }
}


