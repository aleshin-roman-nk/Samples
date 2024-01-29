using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.entity
{
    /// <summary>
    /// Категория покупки. Например Питание, Хозтовары.
    /// Это не класс бюджета. Просто указание что за покупка.
    /// </summary>
    public class ProductCategory : IDbEntity
    {
        public int id { get; set; }
        public string name { get; set; }
    }
}
