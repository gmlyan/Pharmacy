// <copyright file="Product.cs" company="��������-���������">
// Copyright (c) ��������-���������. All rights reserved.
// </copyright>

namespace Domain
{
    using System;
    using System.Collections.Generic;
    using Staff.Extensions;

    /// <summary>
    /// �������������.
    /// </summary>
    public class Maker
    {
        /// <summary>
        /// �������������� ����� ��������� ������ <see cref="Maker"/>.
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="title">��������.</param>
        /// <param name="foundationDate">���� ���������.</param>
        public Author(int id, string title, DateTime foundationDate)
        {
            this.Id = id;
            this.Title = title.TrimOrNull() ?? throw new ArgumentOutOfRangeException(nameof(title));
            this.FoundationDate = foundationDate;
        }

        /// <summary>
        /// ���������� �������������.
        /// </summary>
        public int Id { get; protected set; }

        /// <summary>
        /// �������� �������������.
        /// </summary>
        public string Title { get; protected set; }

        /// <summary>
        /// �������� ��� ������ ���� ��������� �����������.
        /// </summary>
        public DateTime FoundationDate { get; set; }

        /// <summary>
        /// ������ ��������� �������������.
        /// </summary>
        public ISet<Product> Products{ get; protected set; } = new HashSet<Product>();

        /// <summary>
        /// �������� ������� �������������.
        /// </summary>
        /// <param name="product"> ����������� �������. </param>
        /// <returns>
        /// <see langword="true"/> ���� ������� ��� ��������.
        /// </returns>
        public bool AddProduct(Product product)
        {
            var answer = this.Products.TryAdd(product) ?? throw new ArgumentNullException(nameof(product));
            return answer;
        }
    }
}