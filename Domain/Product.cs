// <copyright file="Product.cs" company="��������-���������">
// Copyright (c) ��������-���������. All rights reserved.
// </copyright>

namespace Domain
{
    using System;
    using System.Collections.Generic;
    using Staff.Extensions;

    /// <summary>
    /// �����.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// �������������� ����� ��������� ������ <see cref="Product"/>.
        /// </summary>
        /// <param name="id">���������� �������������.</param>
        /// <param name="title">��������.</param>
        /// <param name="price">����</param>
        /// <param name="quanity">����������.</param>
        /// <param name="makers">������ ��������������.</param>
        public Product(int id, string title, int price, int quanity, params Maker[] makers)
            : this(id, title, new HashSet<Maker>(makers)) 
        {
        }

        /// <summary>
        /// �������������� ����� ��������� ������ <see cref="Product"/>.
        /// </summary>
        /// <param name="id">���������� �������������.</param>
        /// <param name="title">��������.</param>
        /// <param name="price">����</param>
        /// <param name="quanity">����������.</param>
        /// <param name="makers">������ ��������������.</param>
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
        /// �������� ��� ������ ���������� �������������.
        /// </summary>
        public int Id { get; protected set; }

        /// <summary>
        /// �������� ��� ������ �������� ������.
        /// </summary>
        public string Title { get; protected set; }

        /// <summary>
        /// �������� ��� ������ ���� ��������.
        /// </summary>
        public int Price { get; protected set; }

        /// <summary>
        /// �������� ��� ������ ���-�� ��������.
        /// </summary>
        public int quanity { get; protected set; }

        /// <summary>
        /// ������ ��������������.
        /// </summary>
        public ISet<Maker> Makers{ get; protected set; } = new HashSet<Maker>();

        /// <inheritdoc/>
        public override string ToString() => $"{this.Title} {this.Makers.Join()}";
    }
}


